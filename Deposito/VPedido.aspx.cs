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
            MySqlCommand cm = new MySqlCommand("SELECT pedido.id, CONCAT(persona.nombre, ' ', persona.apellido) AS 'NOMBRE Y APELLIDO', servicio_division.descripcion, pedido.fecha FROM pedido INNER JOIN usuario ON pedido.fk_usuario = usuario.id INNER JOIN servicio_division ON usuario.fk_servicio_division = servicio_division.id INNER JOIN persona ON usuario.fk_persona = persona.id WHERE estado = 'PENDIENTE'", coon);
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