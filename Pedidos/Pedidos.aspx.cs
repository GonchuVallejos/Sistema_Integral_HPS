using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data.SqlClient;
using Sistema_Integral_HPS.ABM;
using System.Windows.Forms;

namespace Sistema_Integral_HPS.Pedidos
{
    public partial class Pedidos : System.Web.UI.Page
    {
        Conexion cn = new Conexion();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT id,descripcion,descripcion_adicional FROM articulo WHERE descripcion LIKE '%" + TextBox1.Text + "%' AND habilitado= 'SI'", coon);
            cm.CommandType = System.Data.CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
          
            GridView1.DataSource = dt;
            GridView1.DataBind();
            

            if (GridView1.Rows.Count==0)
            {
                MessageBox.Show("¡NO EXISTE ARTICULO !");
            }
            cn.desconectar();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox2.Visible = true;
            Button2.Visible= true;  
            GridView1.Date
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}