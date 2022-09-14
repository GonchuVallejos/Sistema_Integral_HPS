using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Sistema_Integral_HPS.Deposito
{
    public partial class Ajustes : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                DataColumn ID = dt.Columns.Add("ID ARTICULO", typeof(Int32));
                DataColumn ART = dt.Columns.Add("ARTICULO", typeof(string));
                DataColumn CANTIDAD = dt.Columns.Add("CANTIDAD", typeof(Int32));
                DataColumn TIPO = dt.Columns.Add("TIPO", typeof(Int32));
                DataColumn OBSERVACION = dt.Columns.Add("OBSERVACION", typeof(string));
                ViewState["RECORD"] = dt;

            }
        }
       

        protected void Button1_Click(object sender, EventArgs e) //BUSQUEDA DE ARTICULO CON NOMBRE
        {
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT id,descripcion,descripcion_adicional,stock FROM articulo WHERE descripcion LIKE '%" + TextBox1.Text + "%' AND habilitado= 'SI'", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();

            if (GridView1.Rows.Count == 0) // SI NO EXISTE EL ARTICULO
            {
                string msg = "ARTÍCULO SIN EXISTENCIA!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
            }
            else
            {
                
            }
            coon.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) // AQUI HABILITO PARA QUE PUEDA HACER EL AJUSTE
        {
            Label4.Visible = true;
            Label5.Visible = true;
            DropDownList1.Visible = true;
            TextBox2.Visible = true;
            Label7.Visible = true;
            Label6.Visible = true;
            Label6.Text = Convert.ToString(GridView1.SelectedRow.Cells[1].Text); //TRAIGO EL VALOR A UN LABEL SIMPLEMENTE PARA TENERLO A MANO
            Label8.Visible = true;
            TextBox3.Visible = true;
            Button2.Visible = true;

            GridView1.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            int idp = Convert.ToInt32(Session["usuariologgeado"].ToString()); // GUARDO USUARIO EN VARIABLE
            
            dt = (DataTable)ViewState["RECORD"]; // CARGO EL GRID VIEW CON LOS ARTICULOS SELECCIONADOS A AJUSTAR YA SEA POSITIVO O NEGATIVO (A MODO DE CARRITO DE COMPRAS)

            DataRow row = dt.NewRow();

            row["ID ARTICULO"] = Label6.Text;
            row["ARTICULO"] = Convert.ToString(GridView1.SelectedRow.Cells[2].Text); ;
            row["CANTIDAD"] = TextBox2.Text;
            row["TIPO"] = DropDownList1.SelectedValue;
            row["OBSERVACION"] = TextBox3.Text;

            dt.Rows.Add(row);
            dt.AcceptChanges();
            GridView2.DataSource = dt; //ACTUALIZO GRID VIEW PARA MOSTRAR
            GridView2.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int idp = Convert.ToInt32(Session["usuariologgeado"].ToString());

            MySqlConnection coon = Conexion.getConexion(); // AQUI EMPIEZO A GUARDAR LA "CABECERA DE AJUSTE" DIGAMOS ALGO PARECIDO A PEDIDO Y DETALLE DE PEDIDO
            MySqlCommand cm1 = new MySqlCommand("INSERT INTO ajuste(id,fk_usuario,fecha) VALUES (NULL,'" + idp + "',NULL)", coon);  /* ACA HAY UN ERROR DE LA FECHA*/
            cm1.CommandType = CommandType.Text;
            cm1.ExecuteNonQuery();

            MySqlCommand cm2 = new MySqlCommand("SELECT MAX(id) FROM ajuste", coon); // COMO HIZO GONZA DE BUSCAR EL ULTIMO AJUSTE CARGADO PARA EMPEZAR A CARGAR EL DETALLE
            cm2.CommandType = System.Data.CommandType.Text;

            MySqlDataAdapter da = new MySqlDataAdapter(cm2);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);

            int idajuste = Convert.ToInt32(dt2.Rows[0].ItemArray.GetValue(0).ToString()); // SELECCIONO ESE ID AJUSTE

            dt = (DataTable)ViewState["RECORD"];

            for (int i = 0; i < dt.Rows.Count; i++) //EMPIEZO A CARGAR EL DETALLE_AJUSTE A MODO DE CARRITO DE COMPRA, OSEA SI DESEA AJUSTAR 1 O MAS ARTICULOS
            {
                int ida = Convert.ToInt32(dt.Rows[i]["ID ARTICULO"].ToString());
                int cant = Convert.ToInt32(dt.Rows[i]["CANTIDAD"].ToString());
                int tipo = Convert.ToInt32(dt.Rows[i]["TIPO"].ToString());
                string obs = dt.Rows[i]["OBSERVACION"].ToString();
                MySqlCommand cm = new MySqlCommand("INSERT INTO detalle_ajuste(id,fk_ajuste,fk_articulo,cantidad,tipo_ajuste,observacion) VALUES (NULL,'" + idajuste + "','" + ida + "','" + cant + "','" + tipo + "','" + obs + "')", coon);
                cm.CommandType = CommandType.Text;
                cm.ExecuteNonQuery();
                

                if (tipo == 1) //COMPARO UNO A UNO LOS ARTICULOS SI ES AJUSTE POSITIVO O NEGATIVO, EN BASE A ESO DESCUENTO O SUMO STOCK
                {
                    //SE ACTUALIZA EL STOCK DE ARTICULOS, SUMANDO EL ACTUAL MAS EL AJUSTE
                    MySqlCommand cm3 = new MySqlCommand("UPDATE articulo SET stock = stock + '" + Convert.ToInt16(dt.Rows[i]["CANTIDAD"].ToString()) + "' WHERE id = '" + Convert.ToInt16(dt.Rows[i]["ID ARTICULO"].ToString()) + "'", coon);
                    cm3.CommandType = CommandType.Text;
                    cm3.ExecuteNonQuery();

                    //SE INSERTA EL MOVIMIENTO AJUSTO POSITIVO--- EN PROCESO NO LO TERMINE XD -- SALTA ERROR EN SQL-- TENIA PENSADO HACERLA FACIL Y TRAER EL ID DEL AJUSTE A UN LABEL E INSERTARLO, PERO ESO ES DE COBARDES XD
/*ACA SALTA ERROR*/ MySqlCommand cm6 = new MySqlCommand("INSERT INTO movimiento (id, fk_tipo_movimiento, fk_pedido, fk_adquisicion, fk_ajuste, fk_usuario, estado) VALUES (NULL, 1005, NULL, NULL,'" + idajuste + "', '" + idp + "','CONFIRMADO')", coon);
                    cm6.CommandType = CommandType.Text;
                    cm6.ExecuteNonQuery();
                }
                else
                {
                    //SE ACTUALIZA EL STOCK DE ARTICULOS, RESTANDO EL ACTUAL MENOS LO AJUSTADO
                    MySqlCommand cm3 = new MySqlCommand("UPDATE articulo SET stock = stock - '" + Convert.ToInt16(dt.Rows[i]["CANTIDAD"].ToString()) + "' WHERE id = '" + Convert.ToInt16(dt.Rows[i]["ID ARTICULO"].ToString()) + "'", coon);
                    cm3.CommandType = CommandType.Text;
                    cm3.ExecuteNonQuery();
                     
                    //SE INSERTA EL MOVIMIENTO AJUSTE NEGATIVO --- EN PROCESO NO LO TERMINE XD -- SALTA ERROR EN SQL -- TENIA PENSADO HACERLA FACIL Y TRAER EL ID DEL AJUSTE A UN LABEL E INSERTARLO, PERO ESO ES DE COBARDES XD
/*ACA SALTA ERROR*/ MySqlCommand cm7 = new MySqlCommand("INSERT INTO movimiento (id, fk_tipo_movimiento, fk_pedido, fk_adquisicion, fk_ajuste, fk_usuario, estado) VALUES (NULL, 1005, NULL, NULL,'" + idajuste + "', '" + idp + "','CONFIRMADO')", coon);
                    cm7.CommandType = CommandType.Text;
                    cm7.ExecuteNonQuery();
                }
               
            }
            MessageBox.Show("¡ EL AJUSTE A SIDO CARGADO CORRECTAMENTE !"); // LLEGUE ASI Q PINTAN BIRRAS:)

            
            coon.Close();
            Response.Redirect("/Deposito/IndexDeposito.aspx");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dt = (DataTable)ViewState["RECORD"];
            dt.Rows.RemoveAt(e.RowIndex);

            Session["RECORD"] = dt;

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}