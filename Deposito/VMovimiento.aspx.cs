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
    public partial class VMovimiento : System.Web.UI.Page
    {
        DataTable dta = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT movimiento.id AS id_movimiento, CONCAT(persona.nombre, ' ', persona.apellido) AS usuario, estado, fecha_alta, observacion, fk_pedido FROM movimiento INNER JOIN usuario ON movimiento.fk_usuario = usuario.id INNER JOIN persona ON usuario.fk_persona = persona.id WHERE movimiento.fk_tipo_movimiento = 1003; ", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            da.Fill(dta);

            GridView1.DataSource = dta;
            GridView1.DataBind();

            coon.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}