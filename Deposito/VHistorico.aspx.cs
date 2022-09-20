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

            if (GridView1.Rows.Count == 0)
            {
                string msg = "ARTÍCULO SIN EXISTENCIA!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
            }

            coon.Close();
        }
    }
}