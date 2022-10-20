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
    public partial class RArticulo : System.Web.UI.Page
    {
        DataTable dta = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox2.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                TextBox3.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((Convert.ToDateTime(TextBox3.Text).Date <= DateTime.Now.Date) && (Convert.ToDateTime(TextBox2.Text).Date <= DateTime.Now.Date))
            {
                if (Convert.ToDateTime(TextBox3.Text).Date <= Convert.ToDateTime(TextBox2.Text).Date)
                {
                    DateTime ini = Convert.ToDateTime(TextBox3.Text);
                    DateTime fin = Convert.ToDateTime(TextBox2.Text);
                    MySqlConnection coon = Conexion.getConexion();

                    MySqlCommand cm = new MySqlCommand("SELECT pedido.id AS 'Id Pedido',detalle_pedido.fk_articulo AS 'Id Articulo',articulo.descripcion AS 'Descripcion' ,detalle_pedido.cantidad AS 'Cantidad',unidad_medida.descripcion AS 'Medida',servicio_division.descripcion AS 'Destinado a' FROM detalle_pedido INNER JOIN pedido ON pedido.id=detalle_pedido.fk_pedido INNER JOIN articulo ON articulo.id=detalle_pedido.fk_articulo INNER JOIN unidad_medida ON articulo.fk_unimedidas=unidad_medida.id INNER JOIN servicio_division ON pedido.servicio_division=servicio_division.id  WHERE detalle_pedido.fk_articulo=" + TextBox1.Text + " AND pedido.estado='CONFIRMADO' AND DATE(pedido.fecha) >= '" + ini.ToString("yyyy-MM-dd") + "' AND DATE(pedido.fecha) <= '" + fin.ToString("yyyy-MM-dd") + "'  ", coon);
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

           
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}