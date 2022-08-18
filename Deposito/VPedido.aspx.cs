using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Integral_HPS.Deposito
{
	public partial class VPedido : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            DataTable dta = new DataTable();
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT * FROM pedido WHERE estado = 'PENDIENTE'", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            da.Fill(dta);

            GridView1.DataSource = dta;
            GridView1.DataBind();

            coon.Close();
        }
	}
}