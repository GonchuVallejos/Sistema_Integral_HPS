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
    public partial class RConsumo : System.Web.UI.Page
    {
        DataTable dta = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDrop();
            }
           
        }

        protected void LlenarDrop()
        {
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT * FROM `servicio_division`", coon);
           
            cm.CommandType = System.Data.CommandType.Text;
           

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

         

            DropDownList1.DataValueField = "id";
            DropDownList1.DataTextField = "descripcion";
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();

            coon.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ini = TextBox1.Text;
            string fin = TextBox2.Text;
            MySqlConnection coon = Conexion.getConexion();

            MySqlCommand cm = new MySqlCommand("SELECT pedido.id AS 'Id Pedido',detalle_pedido.fk_articulo AS 'Id Articulo',articulo.descripcion AS 'Descripcion' ,SUM(detalle_pedido.cantidad) AS 'Cantidad',unidad_medida.descripcion AS 'Medida' FROM detalle_pedido INNER JOIN pedido ON pedido.id=detalle_pedido.fk_pedido INNER JOIN articulo ON articulo.id=detalle_pedido.fk_articulo INNER JOIN unidad_medida ON articulo.fk_unimedidas=unidad_medida.id WHERE pedido.servicio_division=" + DropDownList1.Text+" AND pedido.estado='CONFIRMADO' AND articulo.descripcion=articulo.descripcion  GROUP BY articulo.descripcion", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            da.Fill(dta);

            GridView1.DataSource = dta;
            ViewState["RECORD2"] = dta;
            GridView1.DataBind();

            coon.Close();
        }
    }
}