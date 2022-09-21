using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace Sistema_Integral_HPS.Deposito
{
    public partial class VHistorico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT articulo.descripcion AS Nombre, articulo.descripcion_adicional AS Descripcion, historial_precio.fk_adquisicion AS N°Adquisicion, historial_precio.precio AS PRECIO, historial_precio.fecha AS Dia_Adquisicion  FROM `historial_precio` INNER JOIN articulo ON articulo.id=historial_precio.fk_articulo  WHERE fk_articulo LIKE '%" + TextBox1.Text + "%' ORDER BY historial_precio.fecha", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();

            MySqlConnection coon2 = Conexion.getConexion();
            MySqlCommand cm1 = new MySqlCommand("SELECT SUM(precio) AS 'TOTAL ADQUISICION DEL ARTICULO' FROM historial_precio  WHERE fk_articulo LIKE '%" + TextBox1.Text + "%'", coon2);
            cm1.CommandType = CommandType.Text;
            cm1.ExecuteNonQuery();

            MySqlDataAdapter da1 = new MySqlDataAdapter(cm1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            GridView2.DataSource = dt1;
            GridView2.DataBind();
            // SI SE LES OCURRE UNA MEJOR FORMA, HÀGALO!

            if (GridView1.Rows.Count == 0)
            {
                string msg = "ARTÍCULO SIN PRECIOS ACTUALES!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
            }

            coon.Close();
        }
    }
}