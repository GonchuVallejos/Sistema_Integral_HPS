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
    public partial class Adquisicion : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataColumn ID = dt.Columns.Add("ID ARTICULO", typeof(Int32));
                DataColumn ART = dt.Columns.Add("ARTICULO", typeof(string));
                DataColumn CANTIDAD = dt.Columns.Add("CANTIDAD", typeof(Int32));
                DataColumn PRECIO = dt.Columns.Add("PRECIO", typeof(float));
                ViewState["RECORD"] = dt;

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
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
                MessageBox.Show("ARTICULO SIN EXITENCIA!!");               
                Response.Redirect("AArticulo.aspx");
            }
            else
            {

            }
            coon.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label4.Text = Convert.ToString(GridView1.SelectedRow.Cells[1].Text);
            Label4.Visible = true;
            Label5.Text = Convert.ToString(GridView1.SelectedRow.Cells[2].Text);
            Label5.Visible = true;
           
            GridView1.Visible=false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int idp = Convert.ToInt32(Session["usuariologgeado"].ToString()); // GUARDO USUARIO EN VARIABLE

            dt = (DataTable)ViewState["RECORD"]; // CARGO EL GRID VIEW CON LOS ARTICULOS SELECCIONADOS A AJUSTAR YA SEA POSITIVO O NEGATIVO (A MODO DE CARRITO DE COMPRAS)

            DataRow row = dt.NewRow();

            row["ID ARTICULO"] = Label4.Text;
            row["ARTICULO"] = Convert.ToString(GridView1.SelectedRow.Cells[2].Text); ;
            row["CANTIDAD"] = TextBox3.Text;
            row["PRECIO"] = TextBox9.Text;

            dt.Rows.Add(row);
            dt.AcceptChanges();
            GridView2.DataSource = dt; //ACTUALIZO GRID VIEW PARA MOSTRAR
            GridView2.DataBind();
            GridView1.Visible=false;
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dt = (DataTable)ViewState["RECORD"];
            dt.Rows.RemoveAt(e.RowIndex);

            Session["RECORD"] = dt;

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.Equals("PROPIA"))
            {
                Label1.Visible = true;
                TextBox9.Visible = true;
                int idp = Convert.ToInt32(Session["usuariologgeado"].ToString());

                MySqlConnection coon = Conexion.getConexion(); // AQUI EMPIEZO A GUARDAR LA "CABECERA DE ADQUISICION" DIGAMOS ALGO PARECIDO A PEDIDO Y DETALLE DE PEDIDO
                MySqlCommand cm1 = new MySqlCommand("INSERT INTO adquisicion(id,fk_usuario,fecha,orden_compra,año,nexpediente,nremito,tipo,fk_proveedor,dys) VALUES (NULL,'" + idp + "',NULL,'" + TextBox5.Text + "','" + TextBox2.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + DropDownList1.Text + "','" + DropDownList2.Text + "','"+TextBox10.Text+"')", coon);  /* ACA HAY UN ERROR DE LA FECHA*/
                cm1.CommandType = CommandType.Text;
                cm1.ExecuteNonQuery();

                MySqlCommand cm2 = new MySqlCommand("SELECT MAX(id) FROM adquisicion", coon); // COMO HIZO GONZA DE BUSCAR EL ULTIMO AJUSTE CARGADO PARA EMPEZAR A CARGAR EL DETALLE
                cm2.CommandType = System.Data.CommandType.Text;

                MySqlDataAdapter da = new MySqlDataAdapter(cm2);
                DataTable dt2 = new DataTable();
                da.Fill(dt2);

                int idadquisicion = Convert.ToInt32(dt2.Rows[0].ItemArray.GetValue(0).ToString()); // SELECCIONO ESE ID AJUSTE

                dt = (DataTable)ViewState["RECORD"];

                for (int i = 0; i < dt.Rows.Count; i++) //EMPIEZO A CARGAR EL detalle_adquisicion A MODO DE CARRITO DE COMPRA, OSEA SI DESEA AJUSTAR 1 O MAS ARTICULOS
                {
                    int ida = Convert.ToInt32(dt.Rows[i]["ID ARTICULO"].ToString());
                    int cant = Convert.ToInt32(dt.Rows[i]["CANTIDAD"].ToString());
                    MySqlCommand cm = new MySqlCommand("INSERT INTO detalle_adquisicion(id,fk_adquisicion,fk_articulo,cantidad,precio,observacion) VALUES (NULL,'" + idadquisicion + "','" + ida + "','" + cant + "','" + TextBox9.Text + "','" + TextBox4.Text + "')", coon);
                    cm.CommandType = CommandType.Text;
                    cm.ExecuteNonQuery();

                    MySqlCommand cm4 = new MySqlCommand("INSERT INTO historial_precio(id,fk_articulo, fk_adquisicion,precio) VALUES (NULL,'" + ida + "','" + idadquisicion + "','" + TextBox9.Text + "')", coon);
                    cm4.CommandType = CommandType.Text;
                    cm4.ExecuteNonQuery();


                    MySqlCommand cm3 = new MySqlCommand("UPDATE articulo SET stock = stock + '" + Convert.ToInt16(dt.Rows[i]["CANTIDAD"].ToString()) + "' WHERE id = '" + Convert.ToInt16(dt.Rows[i]["ID ARTICULO"].ToString()) + "'", coon);
                    cm3.CommandType = CommandType.Text;
                    cm3.ExecuteNonQuery();

                    //SE INSERTA EL MOVIMIENTO ADQUISICION --- EN PROCESO NO LO TERMINE XD -- SALTA ERROR EN SQL -- TENIA PENSADO HACERLA FACIL Y TRAER EL ID DEL AJUSTE A UN LABEL E INSERTARLO, PERO ESO ES DE COBARDES XD
                    /*ACA SALTA ERROR*/
                    MySqlCommand cm7 = new MySqlCommand("INSERT INTO movimiento (id, fk_tipo_movimiento, fk_pedido, fk_adquisicion, fk_ajuste, fk_usuario, estado) VALUES (NULL, 1001, NULL, '" + idadquisicion + "', NULL, '" + idp + "','CONFIRMADO')", coon);
                    cm7.CommandType = CommandType.Text;
                    cm7.ExecuteNonQuery();

                }
                MessageBox.Show("¡ LA ADQUISICION A SIDO CARGADO CORRECTAMENTE !"); // LLEGUE ASI Q PINTAN BIRRAS:)
                                                                                    //SE ACTUALIZA EL STOCK DE ARTICULOS, sumando EL ACTUAL MAS LO ADQUIRIDO


                coon.Close();
                Response.Redirect("/Deposito/IndexDeposito.aspx");
            }
            if (DropDownList1.SelectedValue.Equals("DONACION"))
            {
                Label1.Visible = false;
                TextBox9.Visible = false;
                int idp = Convert.ToInt32(Session["usuariologgeado"].ToString());

                MySqlConnection coon = Conexion.getConexion(); // AQUI EMPIEZO A GUARDAR LA "CABECERA DE ADQUISICION" DIGAMOS ALGO PARECIDO A PEDIDO Y DETALLE DE PEDIDO
                MySqlCommand cm1 = new MySqlCommand("INSERT INTO adquisicion(id,fk_usuario,fecha,orden_compra,año,nexpediente,nremito,tipo,dona_presta) VALUES (NULL,'" + idp + "',NULL,NULL,NULL,NULL,NULL,'" + DropDownList1.Text + "','" + TextBox8.Text + "')", coon);  /* ACA HAY UN ERROR DE LA FECHA*/
                cm1.CommandType = CommandType.Text;
                cm1.ExecuteNonQuery();

                MySqlCommand cm2 = new MySqlCommand("SELECT MAX(id) FROM adquisicion", coon); // COMO HIZO GONZA DE BUSCAR EL ULTIMO AJUSTE CARGADO PARA EMPEZAR A CARGAR EL DETALLE
                cm2.CommandType = System.Data.CommandType.Text;

                MySqlDataAdapter da = new MySqlDataAdapter(cm2);
                DataTable dt2 = new DataTable();
                da.Fill(dt2);

                int idadquisicion = Convert.ToInt32(dt2.Rows[0].ItemArray.GetValue(0).ToString()); // SELECCIONO ESE ID AJUSTE

                dt = (DataTable)ViewState["RECORD"];

                for (int i = 0; i < dt.Rows.Count; i++) 
                {
                    int ida = Convert.ToInt32(dt.Rows[i]["ID ARTICULO"].ToString());
                    int cant = Convert.ToInt32(dt.Rows[i]["CANTIDAD"].ToString());
                    MySqlCommand cm = new MySqlCommand("INSERT INTO detalle_adquisicion(id,fk_adquisicion,fk_articulo,cantidad,observacion) VALUES (NULL,'" + idadquisicion + "','" + ida + "','" + cant + "','" + TextBox4.Text + "')", coon);
                    cm.CommandType = CommandType.Text;
                    cm.ExecuteNonQuery();


                    MySqlCommand cm3 = new MySqlCommand("UPDATE articulo SET stock = stock + '" + Convert.ToInt16(dt.Rows[i]["CANTIDAD"].ToString()) + "' WHERE id = '" + Convert.ToInt16(dt.Rows[i]["ID ARTICULO"].ToString()) + "'", coon);
                    cm3.CommandType = CommandType.Text;
                    cm3.ExecuteNonQuery();
                                        
                    MySqlCommand cm7 = new MySqlCommand("INSERT INTO movimiento (id, fk_tipo_movimiento, fk_pedido, fk_adquisicion, fk_ajuste, fk_usuario, estado) VALUES (NULL, 1001, NULL, '" + idadquisicion + "', NULL, '" + idp + "','CONFIRMADO')", coon);
                    cm7.CommandType = CommandType.Text;
                    cm7.ExecuteNonQuery();

                }
                MessageBox.Show("¡ LA ADQUISICION A SIDO CARGADO CORRECTAMENTE !"); 
                coon.Close();
                Response.Redirect("/Deposito/IndexDeposito.aspx");
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.Equals("PROPIA"))
            {
                Panel1.Visible = true;
                Panel2.Visible=true;
                MySqlConnection coon = Conexion.getConexion();

                MySqlCommand cm2 = new MySqlCommand("SELECT id, descripcion FROM proveedor", coon);
                cm2.CommandType = System.Data.CommandType.Text;

                MySqlDataAdapter da1 = new MySqlDataAdapter(cm2);
                DataTable dt2 = new DataTable();
                da1.Fill(dt2);

                DropDownList2.DataValueField = "id";
                DropDownList2.DataTextField = "descripcion";
                DropDownList2.DataSource = dt2;
                DropDownList2.DataBind();
            }
            if (DropDownList1.SelectedValue.Equals("DONACION"))
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                Panel3.Visible = true;
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}