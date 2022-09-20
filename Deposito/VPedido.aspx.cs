﻿using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using MySql.Data.MySqlClient;
using Sistema_Integral_HPS.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Printing;
using System.Drawing;
using System.Text;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.InteropServices;



namespace Sistema_Integral_HPS.Deposito
{
	public partial class VPedido : System.Web.UI.Page
	{
       
        DataTable dt = new DataTable();
        string id;
        //Declaramos variables
        System.Drawing.Font printFont = null;
        SolidBrush myBrush = new SolidBrush(Color.Black);
        string fontName = "Lucida Console";
        int fontSize = 8;
        Graphics gfx = null;
        int PosX=10,PosY=5;
        int PosXi = 180, PosYi = 5;

        public System.Drawing.Font PrintFont { get => printFont; set => printFont = value; }

        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                DataTable dta = new DataTable();
                MySqlConnection coon = Conexion.getConexion();
                MySqlCommand cm = new MySqlCommand("SELECT pedido.id, CONCAT(persona.nombre, ' ', persona.apellido) AS 'NOMBRE Y APELLIDO', servicio_division.descripcion, pedido.fecha FROM pedido INNER JOIN usuario ON pedido.fk_usuario = usuario.id INNER JOIN servicio_division ON usuario.fk_servicio_division = servicio_division.id INNER JOIN persona ON usuario.fk_persona = persona.id WHERE estado = 'PENDIENTE'", coon);
                cm.CommandType = CommandType.Text;
                cm.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(dta);

                GridView1.DataSource = dta;
                GridView1.DataBind();
                ViewState["RECORD"] = dt;
                coon.Close();
            }
           
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dta1 = new DataTable();
            Panel2.Visible = true;
            Panel1.Visible = true;
            TextBox1.Text = Convert.ToString(GridView1.SelectedRow.Cells[2].Text); 
            TextBox2.Text = Convert.ToString(GridView1.SelectedRow.Cells[4].Text);
            
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT detalle_pedido.id as iddetalle, detalle_pedido.fk_pedido as idpedido, detalle_pedido.fk_articulo,articulo.descripcion,detalle_pedido.cantidad,unidad_medida.descripcion AS unidad_medida,detalle_pedido.observacion FROM detalle_pedido INNER JOIN articulo ON detalle_pedido.fk_articulo = articulo.id INNER JOIN unidad_medida ON articulo.fk_unimedidas=unidad_medida.id INNER JOIN pedido ON detalle_pedido.fk_pedido='" + Convert.ToString(GridView1.SelectedRow.Cells[1].Text) + "'GROUP BY detalle_pedido.fk_articulo", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            da.Fill(dta1);
            GridView2.DataSource = dta1;
            GridView2.DataBind();
            ViewState["RECORD2"] = dta1;
            coon.Close();

            Panel2.Visible = true;
            GridView1.Visible = false;
        }
        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dta1 = (DataTable)ViewState["RECORD2"];

            GridViewRow row = GridView2.Rows[e.RowIndex];
            dta1.Rows[row.DataItemIndex]["CANTIDAD"] = ((TextBox)(row.Cells[3].Controls[0])).Text;
            dta1.Rows[row.DataItemIndex]["OBSERVACION"] = ((TextBox)(row.Cells[5].Controls[0])).Text;

            GridView2.EditIndex = -1;

            Session["RECORD2"] = dta1;

            GridView2.DataSource = dta1;
            GridView2.DataBind();

            btn_guardar.Visible = true;
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;

            DataTable dta1 = (DataTable)ViewState["RECORD2"];
            GridView2.DataSource = dta1;
            GridView2.DataBind();

            btn_guardar.Visible = false;
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;

            DataTable dta1 = (DataTable)ViewState["RECORD2"];
            GridView2.DataSource = dta1;
            GridView2.DataBind();

            btn_guardar.Visible = true;
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Deposito/IndexDeposito.aspx");
        }
        protected void btn_verpedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Deposito/VPedido.aspx");
        }
        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            MySqlConnection coon = Conexion.getConexion();

            DataTable dta1 = (DataTable)ViewState["RECORD2"];

            for (int i = 0; i < dta1.Rows.Count; i++)
            {
                //SE MODIFICA LA CANTIDAD SOLICITADA Y SE AGREGA LA OBSERVACION DE PORQUE SE MODIFICA
                MySqlCommand cm = new MySqlCommand("UPDATE detalle_pedido SET detalle_pedido.cantidad = '" + dta1.Rows[i]["CANTIDAD"].ToString() + "', detalle_pedido.observacion = '" + dta1.Rows[i]["OBSERVACION"].ToString() + "' WHERE id = '" + dta1.Rows[i]["iddetalle"].ToString() + "';", coon);
                cm.CommandType = CommandType.Text;
                cm.ExecuteNonQuery();

                //SE ACTUALIZA EL STOCK DE ARTICULOS, RESTANDO EL ACTUAL MENOS LO SUMINISTRADO
                MySqlCommand cm3 = new MySqlCommand("UPDATE articulo SET stock = stock - '" + Convert.ToInt16(dta1.Rows[i]["CANTIDAD"].ToString()) + "' WHERE id = '" + Convert.ToInt16(dta1.Rows[i]["fk_articulo"].ToString()) + "'", coon);
                cm3.CommandType = CommandType.Text;
                cm3.ExecuteNonQuery();
            }

            id = Session["usuariologgeado"].ToString();

            //SE ACTUALIZA EL ESTADO DEL PEDIDO A CONFIRMADO
            MySqlCommand cm2 = new MySqlCommand("UPDATE pedido SET estado = 'CONFIRMADO' WHERE id = '" + dta1.Rows[0]["idpedido"].ToString() + "'", coon);
            cm2.CommandType = CommandType.Text;
            cm2.ExecuteNonQuery();

            //SE INSERTA EL MOVIMIENTO
            MySqlCommand cm1 = new MySqlCommand("INSERT INTO movimiento (id, fk_tipo_movimiento, fk_pedido, fk_adquisicion, fk_ajuste, fk_usuario, estado,retira) VALUES (NULL, 1003, '" + dta1.Rows[0]["idpedido"].ToString() + "', NULL, NULL, '" + id + "','CONFIRMADO', '" + TextBox3.Text + "')", coon);
            cm1.CommandType = CommandType.Text;
            cm1.ExecuteNonQuery();

            coon.Close();
            Response.Redirect("/Deposito/IndexDeposito.aspx");

            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Table1_DataBinding(object sender, EventArgs e)
        {

        }

        protected void lnkPrint_Click(object sender, EventArgs e)
        {

        }
        private void ExportGridToPDF()
        {
          /*  string Texto_Html = string.Empty;
          //  Texto_Html = Resources.PDFPedido.ToString();
            Texto_Html = Texto_Html.Replace("@fecharegistro", DateTime.Now.ToString());
            string filas = string.Empty;
            foreach (GridView row in GridView1.Rows)
            {
                //ver la parte de agregar los datos del gridview al pdf 
                //filas += "<tr>";
                //filas += "<td>" + row.["Codigo"].Value.ToString() + "</td>";
                //filas += "<td>" + row.["Articulo"].Value.ToString() + "</td>";
                //filas += "<td>" + row.["Cantidad"].Value.ToString() + "</td>";

            }
            //Texto_Html = Texto_Html.Replace("@filas", filas);
            //SaveFileDialog savefile = new SaveFileDialog();
            //savefile.FileName = string.Format("Salida_{0}.pdf");
            //savefile.Filter = "Pdf Files|*.pdf";

            //if (savefile.ShowDialog() == DialogResult.OK)
            //{
            //    using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
            //    {
            //        //Creamos un nuevo documento y lo definimos como PDF
            //        Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

            //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
            //        pdfDoc.Open();

            //        bool obtenido = true;
            //        // byte[] byteimage = DatoLogica.Instancia.ObtenerLogo(out obtenido);
            //        if (obtenido)
            //        {
            //            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteimage);
            //            img.ScaleToFit(60, 60);
            //            img.Alignment = iTextSharp.text.Image.UNDERLYING;
            //            img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
            //            pdfDoc.Add(img);
            //        }

            //        using (StringReader sr = new StringReader(Texto_Html))
            //        {
            //            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            //        }

            //        pdfDoc.Close();
            //        stream.Close();
            //        MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition", "attachment;filename=Comprobante.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //StringWriter sw = new StringWriter();
                //HtmlTextWriter hw = new HtmlTextWriter(sw);
                //GridView2.RenderControl(hw);
                //StringReader sr = new StringReader(sw.ToString());
                //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                //pdfDoc.Open();
                //htmlparser.Parse(sr);
                //pdfDoc.Close();
                //Response.Write(pdfDoc);
                //Response.End();
                //GridView1.AllowPaging = true;
                //GridView1.DataBind();
            //}*/
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Permito que el usuario seleccione una impresora
            // Abro el cuadro de dialogo
            System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();

            // Creo la instacia de la configuarion de impresion
            pd.PrinterSettings = new PrinterSettings();

            // Creo el tipo de letra que se va a usar
            printFont = new System.Drawing.Font(fontName, fontSize, FontStyle.Regular);

            //creo el documento con el que vamos a trabjar
            PrintDocument doc = new PrintDocument();

            //Determina la impresora que vamos a usar es la que seleccionamos en la configuracion
            doc.PrinterSettings.PrinterName = pd.PrinterSettings.PrinterName;

            //Nombre en del documento
            doc.DocumentName = "Impresion de Prueba";

            //Organiza la pagina para posteriomente imprimirla
            doc.PrintPage += new PrintPageEventHandler(pr_PrintPage);

            //Imprime el documento
            doc.Print();

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //funcion que se encarga de imprimir
        private void pr_PrintPage(Object sender, PrintPageEventArgs e)
        {
            RectangleF srcRect = new RectangleF(50.0F, 50.0F, 150.0F, 150.0F);
            GraphicsUnit units = GraphicsUnit.Pixel;
            System.Drawing.Image newImage = System.Drawing.Image.FromFile("C:/Users/SISTEMAS-SIS/Source/Repos/Sistema_Integral_HPS/Deposito/img/Logo HPS.png");
            e.Graphics.PageUnit = GraphicsUnit.Millimeter; //unidades de la impresion
            gfx = e.Graphics;
            gfx.DrawImage(newImage,PosXi,PosYi,15,15);
            gfx.DrawString("HOSPITAL PABLO SORIA\n\n\n", printFont, myBrush, PosX, PosY, new StringFormat());
            gfx.DrawString("------------------------------\n \n", printFont, myBrush, PosX, PosY+5, new StringFormat());
            gfx.DrawString("ID ARTICULO\n \n \n", printFont, myBrush, PosX, PosY+10, new StringFormat());
            gfx.DrawString("DESCRIPCION\n \n \n", printFont, myBrush, PosX+30, PosY + 10, new StringFormat());
            gfx.DrawString("CANTIDAD\n \n \n", printFont, myBrush, PosX+100, PosY + 10, new StringFormat());
            //Agregamos tantas lineas como querramos y posiciones variadas.
            for (int i = 0; i <  GridView2.Rows.Count; i++)
            {
                gfx.DrawString("\n \n \n \n \n" + GridView2.Rows[i].Cells[1].Text+ "\n \n", printFont, myBrush, PosX, PosY+(i*10), new StringFormat());
                gfx.DrawString("\n \n \n \n \n" + GridView2.Rows[i].Cells[2].Text + "\n \n", printFont, myBrush, PosX+30, PosY + (i * 10), new StringFormat());
                gfx.DrawString("\n \n \n \n \n" + GridView2.Rows[i].Cells[3].Text + "\n \n", printFont, myBrush, PosX+100, PosY + (i * 10), new StringFormat());

            }

            gfx.DrawString("FIRMA RECIBE: \n \n", printFont, myBrush, PosXi-30, PosY+((GridView2.Rows.Count + 1)*10), new StringFormat());
            gfx.DrawString("________________________________Linea de corte________________________________\n \n", printFont, myBrush, PosX, PosY + ((GridView2.Rows.Count + 2) * 10), new StringFormat());

        }




    }


}
      
