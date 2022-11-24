using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace Sistema_Integral_HPS.Deposito
{
    public partial class VMovimiento : System.Web.UI.Page
    {
        DataTable dta = new DataTable();
        //Declaramos variables
        System.Drawing.Font printFont = null;
        SolidBrush myBrush = new SolidBrush(Color.Black);
        string fontName = "Lucida Console";
        int fontSize = 8;
        Graphics gfx = null;
        int PosX = 10, PosY = 5;
        int PosXi = 180, PosYi = 5;
        int n = 16, m = 8;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MySqlConnection coon = Conexion.getConexion();

                MySqlCommand cm2 = new MySqlCommand("SELECT id, descripcion FROM tipo_movimiento", coon);
                cm2.CommandType = System.Data.CommandType.Text;

                MySqlDataAdapter da1 = new MySqlDataAdapter(cm2);
                DataTable dt = new DataTable();
                da1.Fill(dt);

                DropDownList1.DataValueField = "id";
                DropDownList1.DataTextField = "descripcion";
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();
                
            }
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            DataTable dta1 = (DataTable)ViewState["RECORD2"];
            DataTable dta2 = new DataTable();
            Button2.Visible = true; 
     
            MySqlConnection coon = Conexion.getConexion();
            
            int idm = Convert.ToInt32(dta1.Rows[0]["fk_tipo_movimiento"].ToString());
            if (idm ==1003)
            {
                int idp= Convert.ToInt32(GridView1.SelectedDataKey.Values[0].ToString());
                MySqlCommand cm1 = new MySqlCommand("SELECT detalle_pedido.fk_articulo AS 'ID ARTICULO',detalle_pedido.cantidad AS 'CANTIDAD',articulo.descripcion AS 'ARTICULO',detalle_pedido.observacion AS 'OBSERVACION' FROM detalle_pedido INNER JOIN articulo  ON detalle_pedido.fk_articulo=articulo.id WHERE detalle_pedido.fk_pedido='" + idp +"' GROUP BY detalle_pedido.fk_articulo", coon);
                MySqlDataAdapter da = new MySqlDataAdapter(cm1);
                da.Fill(dta2);
                GridView2.DataSource = dta2;
                GridView2.DataBind();
            }
            coon.Close();
        }

        protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView5.Visible = false;
            DataTable dta1 = (DataTable)ViewState["RECORD2"];
            DataTable dta2 = new DataTable();

            MySqlConnection coon = Conexion.getConexion();

            int idm = Convert.ToInt32(dta1.Rows[0]["fk_tipo_movimiento"].ToString());
            if (idm == 1002)
            {
                int idp = Convert.ToInt32(GridView5.SelectedDataKey.Values[3].ToString());
                MySqlCommand cm1 = new MySqlCommand("SELECT detalle_pedido_provision.fk_articulo AS 'ID ARTICULO',detalle_pedido_provision.cantidad AS 'CANTIDAD',articulo.descripcion AS 'ARTICULO',detalle_pedido_provision.observacion AS 'OBSERVACION' FROM detalle_pedido_provision INNER JOIN articulo  ON detalle_pedido_provision.fk_articulo=articulo.id WHERE detalle_pedido_provision.fk_pedido_provision='" + idp + "' GROUP BY detalle_pedido_provision.fk_articulo", coon);
                MySqlDataAdapter da = new MySqlDataAdapter(cm1);
                da.Fill(dta2);
                GridView2.DataSource = dta2;
                GridView2.DataBind();
            }
            coon.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.ToString() == "1003")
            {
                GridView4.Visible = false;
                GridView1.Visible = true;
                GridView3.Visible = false;
                GridView5.Visible = false;
                MySqlConnection coon = Conexion.getConexion();

                MySqlCommand cm = new MySqlCommand("SELECT pedido.id AS idpedido, fk_pedido, fk_tipo_movimiento, fk_adquisicion, fk_ajuste, CONCAT(persona.nombre, ' ', persona.apellido) AS usuario_confirma, movimiento.estado AS estado, movimiento.observacion AS observacion, pedido.servicio_division AS idservicio, servicio_division.descripcion AS servicio_pide, movimiento.retira AS retira, movimiento.fecha_alta AS fecha_alta FROM `movimiento` INNER JOIN usuario ON movimiento.fk_usuario = usuario.id INNER JOIN persona ON usuario.fk_persona = persona.id INNER JOIN pedido ON movimiento.fk_pedido = pedido.id INNER JOIN servicio_division ON servicio_division.id = pedido.servicio_division WHERE `fk_tipo_movimiento` = '" + DropDownList1.SelectedValue + "' ORDER BY movimiento.fecha_alta DESC", coon);
                cm.CommandType = CommandType.Text;
                cm.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(dta);

                GridView1.DataSource = dta;
                ViewState["RECORD2"] = dta;
                GridView1.DataBind();

                coon.Close();
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            else
            {
                if (DropDownList1.SelectedValue.ToString() == "1001")
                {
                    GridView1.Visible = false;
                    GridView3.Visible = true;
                    GridView4.Visible = false;
                    GridView5.Visible = false;

                    MySqlConnection coon = Conexion.getConexion();

                    //********************************************
                    //FILTRAR POR TIPO DE ADQUISICION: DONACION O PROPIA
                    //********************************************

                    MySqlCommand cm = new MySqlCommand("SELECT movimiento.id AS id_movimiento, CONCAT(persona.nombre, ' ', persona.apellido) AS usuario, estado, movimiento.fecha_alta, observacion, fk_pedido,fk_adquisicion,fk_ajuste, fk_tipo_movimiento,unidad_seccion.descripcion AS unidad_seccion, adquisicion.tipo AS tipo,adquisicion.dys AS dys FROM movimiento INNER JOIN usuario ON movimiento.fk_usuario = usuario.id INNER JOIN persona ON usuario.fk_persona = persona.id INNER JOIN unidad_seccion ON usuario.fk_unidad_seccion = unidad_seccion.id INNER JOIN adquisicion ON movimiento.fk_adquisicion = adquisicion.id WHERE fk_tipo_movimiento = '" + DropDownList1.SelectedValue + "' GROUP BY movimiento.fk_pedido, movimiento.fk_adquisicion, movimiento.fk_ajuste ORDER BY movimiento.fecha_alta DESC", coon);
                    cm.CommandType = CommandType.Text;
                    cm.ExecuteNonQuery();

                    //********************************************
                    //MOSTRAR EN EL DETALLE ADQUISICION, UN ENCABEZADO CON LOS CAMPOS 
                    //ORDEN DE COMPRA, EXPEDIENTE, REMITO, PROVEEDOR, AÑO Y ESTADO
                    // ASI COMO EN 'VER PEDIDOS'
                    //********************************************

                    MySqlDataAdapter da = new MySqlDataAdapter(cm);
                    da.Fill(dta);

                    GridView3.DataSource = dta;
                    ViewState["RECORD3"] = dta;
                    GridView3.DataBind();

                    coon.Close();
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
                else
                {
                    if (DropDownList1.SelectedValue.ToString() == "1005")
                    {
                        GridView4.Visible = true;
                        GridView3.Visible = false;
                        GridView1.Visible = false;
                        GridView5.Visible = false;
                        MySqlConnection coon = Conexion.getConexion();

                        MySqlCommand cm = new MySqlCommand("SELECT movimiento.id AS id_movimiento, CONCAT(persona.nombre, ' ', persona.apellido) AS usuario, estado, movimiento.fecha_alta, observacion, fk_pedido,fk_adquisicion,fk_ajuste, fk_tipo_movimiento FROM movimiento INNER JOIN usuario ON movimiento.fk_usuario = usuario.id INNER JOIN persona ON usuario.fk_persona = persona.id WHERE fk_tipo_movimiento = '" + DropDownList1.SelectedValue + "' GROUP BY movimiento.fk_pedido, movimiento.fk_adquisicion, movimiento.fk_ajuste ORDER BY movimiento.fecha_alta DESC", coon);
                        cm.CommandType = CommandType.Text;
                        cm.ExecuteNonQuery();

                        MySqlDataAdapter da = new MySqlDataAdapter(cm);
                        da.Fill(dta);

                        GridView4.DataSource = dta;
                        ViewState["RECORD4"] = dta;
                        GridView4.DataBind();

                        coon.Close();
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                    }
                    else
                    {
                        GridView4.Visible = false;
                        GridView1.Visible = false;
                        GridView3.Visible = false;
                        GridView5.Visible = true;
                        MySqlConnection coon = Conexion.getConexion();

                        MySqlCommand cm = new MySqlCommand("SELECT pedido_provision.id AS idpedido, fk_pedido, fk_pedido_provision, fk_tipo_movimiento, fk_adquisicion, fk_ajuste,CONCAT(persona.nombre, ' ', persona.apellido) AS usuario_confirma, movimiento.estado AS estado, movimiento.observacion AS observacion, pedido_provision.servicio_division AS idservicio, servicio_division.descripcion AS servicio_pide, movimiento.retira AS retira, movimiento.fecha_alta AS fecha_alta FROM `movimiento` INNER JOIN usuario ON movimiento.fk_usuario = usuario.id INNER JOIN persona ON usuario.fk_persona = persona.id INNER JOIN pedido_provision ON movimiento.fk_pedido_provision = pedido_provision.id INNER JOIN servicio_division ON servicio_division.id = pedido_provision.servicio_division WHERE `fk_tipo_movimiento` = '" + DropDownList1.SelectedValue + "' ORDER BY movimiento.fecha_alta DESC", coon);
                        cm.CommandType = CommandType.Text;
                        cm.ExecuteNonQuery();

                        MySqlDataAdapter da = new MySqlDataAdapter(cm);
                        da.Fill(dta);

                        GridView5.DataSource = dta;
                        ViewState["RECORD2"] = dta;
                        GridView5.DataBind();

                        coon.Close();
                        GridView2.DataSource = null;
                        GridView2.DataBind();
                    }
                }
            }

        }
        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView4.Visible = false;
            DataTable dta1 = (DataTable)ViewState["RECORD4"];
            DataTable dta2 = new DataTable();

            MySqlConnection coon = Conexion.getConexion();

            int idm = Convert.ToInt32(dta1.Rows[0]["fk_tipo_movimiento"].ToString());
           
            if (idm == 1005)
            {
                int idp = Convert.ToInt32(GridView4.SelectedDataKey.Values[1].ToString());
                MySqlCommand cm1 = new MySqlCommand("SELECT detalle_ajuste.fk_articulo AS 'ID ARTICULO',detalle_ajuste.cantidad AS 'CANTIDAD',articulo.descripcion AS 'ARTICULO',detalle_ajuste.tipo_ajuste AS 'TIPO AJUSTE',detalle_ajuste.observacion AS 'OBSERVACION' FROM detalle_ajuste INNER JOIN articulo ON detalle_ajuste.fk_articulo=articulo.id WHERE fk_ajuste='" + idp + "' GROUP BY detalle_ajuste.fk_articulo", coon);
                MySqlDataAdapter da = new MySqlDataAdapter(cm1);
                da.Fill(dta2);
                GridView2.DataSource = dta2;
                GridView2.DataBind();
            
            }
            coon.Close();

        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView3.Visible = false;
            DataTable dta1 = (DataTable)ViewState["RECORD3"];
            DataTable dta3 = new DataTable();

            MySqlConnection coon = Conexion.getConexion();


            int idm = Convert.ToInt32(dta1.Rows[0]["fk_tipo_movimiento"].ToString());

            if (idm == 1001)
            {
                int idp = Convert.ToInt32(GridView3.SelectedDataKey.Values[2].ToString());
                MySqlCommand cm1 = new MySqlCommand("SELECT detalle_adquisicion.fk_articulo AS 'ID ARTICULO',detalle_adquisicion.cantidad AS 'CANTIDAD',articulo.descripcion AS 'ARTICULO', detalle_adquisicion.precio AS PRECIO,adquisicion.tipo AS 'TIPO',adquisicion.dys AS 'DYS',detalle_adquisicion.observacion AS 'OBSERVACION' FROM detalle_adquisicion INNER JOIN articulo ON detalle_adquisicion.fk_articulo=articulo.id INNER JOIN adquisicion ON adquisicion.id=detalle_adquisicion.fk_adquisicion WHERE fk_adquisicion='" + idp + "' GROUP BY detalle_adquisicion.fk_articulo", coon);
                MySqlDataAdapter da1 = new MySqlDataAdapter(cm1);
                da1.Fill(dta3);
                GridView2.DataSource = dta3;
                GridView2.DataBind();
  
            }
            coon.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Permito que el usuario seleccione una impresora
            // Abro el cuadro de dialogo
            System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();

            // Creo la instacia de la configuarion de impresion
            //pd.PrinterSettings = new PrinterSettings();

            // Creo el tipo de letra que se va a usar
            printFont = new System.Drawing.Font(fontName, fontSize, FontStyle.Regular);

            //creo el documento con el que vamos a trabjar
            PrintDocument doc = new PrintDocument();

            //Determina la impresora que vamos a usar es la que seleccionamos en la configuracion
            doc.PrinterSettings.PrinterName = pd.PrinterSettings.PrinterName;

            //Nombre en del documento
            // doc.DocumentName = "Impresion de Prueba";

            //Organiza la pagina para posteriomente imprimirla
            doc.PrintPage += new PrintPageEventHandler(pr_PrintPage);

            //Imprime el documento
            doc.Print();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pr_PrintPage(Object sender, PrintPageEventArgs e)
        {
            RectangleF srcRect = new RectangleF(50.0F, 50.0F, 150.0F, 150.0F);
            GraphicsUnit units = GraphicsUnit.Pixel;
            System.Drawing.Image newImage = System.Drawing.Image.FromFile("\\\\SERVERSISTEMAS\\Users\\Administrador\\source\\repos\\Sistema_Integral_HPS\\Deposito\\img\\Logo_HPS.png");
            e.Graphics.PageUnit = GraphicsUnit.Millimeter; //unidades de la impresion
            gfx = e.Graphics;
            gfx.DrawImage(newImage, PosXi, PosYi, 15, 15);
            gfx.DrawString("HOSPITAL PABLO SORIA\n\n\n", printFont, myBrush, PosX, PosY, new StringFormat());
           // gfx.DrawString("Fecha de pedido: " + DateTime.Now, printFont, myBrush, PosX + 50, PosY, new StringFormat());
          //  gfx.DrawString("ID PEDIDO: " + GridView2.SelectedRow.Cells[1].Text, printFont, myBrush, PosX + 130, PosY, new StringFormat());
           // gfx.DrawString("Sumistrado a: " + GridView2.SelectedRow.Cells[3].Text, printFont, myBrush, PosX, PosY + 3, new StringFormat());
          //  gfx.DrawString("Pedido por: " + GridView2.SelectedRow.Cells[2].Text, printFont, myBrush, PosX + 110, PosY + 3, new StringFormat());
            gfx.DrawString("------------------------------\n \n", printFont, myBrush, PosX, PosY + 5, new StringFormat());
            gfx.DrawString("ID ARTICULO\n \n \n", printFont, myBrush, PosX, PosY + 10, new StringFormat());
            gfx.DrawString("DESCRIPCION\n \n \n", printFont, myBrush, PosX + 30, PosY + 10, new StringFormat());
            gfx.DrawString("CANTIDAD\n \n \n", printFont, myBrush, PosX + 100, PosY + 10, new StringFormat());
            gfx.DrawString("OBSERVACION\n \n \n", printFont, myBrush, PosX + 150, PosY + 10, new StringFormat());
            //Agregamos tantas lineas como querramos y posiciones variadas.
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                gfx.DrawString("\n \n \n \n \n" + GridView2.Rows[i].Cells[0].Text + "\n ", printFont, myBrush, PosX, PosY + (i * m), new StringFormat());
                gfx.DrawString("\n \n \n \n \n" + GridView2.Rows[i].Cells[2].Text + "\n", printFont, myBrush, PosX + 30, PosY + (i * m), new StringFormat());
                gfx.DrawString("\n \n \n \n \n" + GridView2.Rows[i].Cells[1].Text + "\n", printFont, myBrush, PosX + 100, PosY + (i * m), new StringFormat());
                gfx.DrawString("\n \n \n \n \n" + GridView2.Rows[i].Cells[3].Text + "\n", printFont, myBrush, PosX + 150, PosY + (i * m), new StringFormat());
            }

          //  gfx.DrawString("FIRMA RECIBE: \n \n", printFont, myBrush, PosXi - 30, PosY + ((GridView2.Rows.Count + 1) * 10), new StringFormat());
          //  gfx.DrawString("____________________________________________Linea de corte____________________________________________\n ", printFont, myBrush, PosX, PosY + ((GridView2.Rows.Count + 2) * m), new StringFormat());

           
        }
      
    }
}