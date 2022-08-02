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
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               

                DataColumn ID = dt.Columns.Add("ID ARTICULO", typeof(Int32));
                DataColumn ART = dt.Columns.Add("ARTICULO", typeof(string));
                DataColumn CANTIDAD = dt.Columns.Add("CANTIDAD", typeof(Int32));
                ViewState["RECORD"] = dt;

            }
           
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
            string idv =  GridView1.SelectedDataKey.Value.ToString();
            Label1.Text = Convert.ToString(idv);
            // MessageBox.Show("¡ARTICULO SELECCIONADO: "+Label1.Text+" !");
            Label2.Visible = true;
            Label2.Text = Convert.ToString( GridView1.SelectedRow.Cells[2].Text );
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            
            dt = (DataTable)ViewState["RECORD"];


            DataRow row = dt.NewRow();

            row["ID ARTICULO"] = Label1.Text;
            row["ARTICULO"] = Label2.Text;
            row["CANTIDAD"] = TextBox2.Text;

            dt.Rows.Add(row);
            dt.AcceptChanges();
            GridView2.DataSource = dt;
            GridView2.DataBind();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {


            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("INSERT INTO detalle_pedido(id,fk_pedido,fk_articulo,cantidad,observacion) VALUES (NULL,'1000001','" + Label1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')", coon);
            cm.CommandType = System.Data.CommandType.Text;
            cm.ExecuteNonQuery();

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}