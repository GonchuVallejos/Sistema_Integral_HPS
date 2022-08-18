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
    public partial class VPedidos : System.Web.UI.Page
    {
        DataTable dta = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable dta = new DataTable();
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT pedido.id,articulo.descripcion, detalle_pedido.fk_articulo, detalle_pedido.cantidad FROM detalle_pedido INNER JOIN pedido ON detalle_pedido.id = pedido.id INNER JOIN articulo ON articulo.id = detalle_pedido.fk_articulo;", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            //DataTable dt = new DataTable();
            da.Fill(dta);

            GridView1.DataSource = dta;
            GridView1.DataBind();

           
            coon.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT pedido.id,articulo.descripcion, detalle_pedido.fk_articulo, detalle_pedido.cantidad, unidad_medida.descripcion FROM detalle_pedido INNER JOIN pedido ON detalle_pedido.id = pedido.id INNER JOIN articulo ON articulo.id = detalle_pedido.fk_articulo INNER JOIN unidad_medida ON articulo.fk_unimedidas=unidad_medida.id WHERE detalle_pedido.fk_pedido="+TextBox1.Text+";", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            //DataTable dt = new DataTable();
            da.Fill(dta);

            GridView1.DataSource = dta;
            GridView1.DataBind();


            coon.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
        }
    }
}