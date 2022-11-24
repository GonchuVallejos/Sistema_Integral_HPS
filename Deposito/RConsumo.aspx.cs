 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
//Registro del consumo por servicio
namespace Sistema_Integral_HPS.Deposito
{
    public partial class RConsumo : System.Web.UI.Page
    {
        DataTable dta = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                TextBox2.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                LlenarDrop();
            }
           
        }

        protected void LlenarDrop()
        {
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT * FROM `servicio_division`", coon);
            MySqlCommand cm1 = new MySqlCommand("SELECT * FROM `familia`", coon);
            cm.CommandType = System.Data.CommandType.Text;
            cm1.CommandType = System.Data.CommandType.Text;


            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            MySqlDataAdapter da1 = new MySqlDataAdapter(cm1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

           
           

            DropDownList1.DataValueField = "id";
            DropDownList1.DataTextField = "descripcion";
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();


            DropDownList2.DataValueField = "id";
            DropDownList2.DataTextField = "descripcion";
            DropDownList2.DataSource = dt1;
            DropDownList2.DataBind();


            coon.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if ((Convert.ToDateTime(TextBox1.Text).Date <= DateTime.Now.Date) && (Convert.ToDateTime(TextBox2.Text).Date <= DateTime.Now.Date))
            {
                if (Convert.ToDateTime(TextBox1.Text).Date <= Convert.ToDateTime(TextBox2.Text).Date)
                {
                    DateTime ini = Convert.ToDateTime(TextBox1.Text);
                    DateTime fin = Convert.ToDateTime(TextBox2.Text);
                    MySqlConnection coon = Conexion.getConexion();

                    MySqlCommand cm = new MySqlCommand("SELECT pedido.id AS 'Id Pedido',detalle_pedido.fk_articulo AS 'Id Articulo',articulo.descripcion AS 'Descripcion' ,SUM(detalle_pedido.cantidad) AS 'Cantidad',unidad_medida.descripcion AS 'Medida' FROM detalle_pedido INNER JOIN pedido ON pedido.id=detalle_pedido.fk_pedido INNER JOIN articulo ON articulo.id=detalle_pedido.fk_articulo INNER JOIN unidad_medida ON articulo.fk_unimedidas=unidad_medida.id WHERE pedido.servicio_division=" + DropDownList1.Text + " AND pedido.estado='CONFIRMADO' AND DATE(pedido.fecha) >= '" + ini.ToString("yyyy-MM-dd") + "' AND DATE(pedido.fecha) <= '" + fin.ToString("yyyy-MM-dd") + "' AND articulo.fk_familias="+ DropDownList2.Text+" GROUP BY articulo.descripcion", coon);
                    cm.CommandType = CommandType.Text;
                    cm.ExecuteNonQuery();

                    MySqlDataAdapter da = new MySqlDataAdapter(cm);
                    da.Fill(dta);

                    GridView1.DataSource = dta;
                    ViewState["RECORD2"] = dta;
                    GridView1.DataBind();

                    coon.Close();
                }
                else
                {
                    string msg = "LA FECHA DE INICIO DEBE SER MENOR QUE LA FINAL";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
                }
            }
            else
            {
                string msg = "FECHA INGRESADA INCORRECTA, DEBE SER MENOR A LA FECHA ACTUAL";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
            }

            Button2.Visible = true;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button1.Visible = false;
            
        }

       
    }
}