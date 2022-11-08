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
using System.Windows.Forms;

namespace Sistema_Integral_HPS.Deposito
{
    public partial class IndexDeposito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dta1 = new DataTable();
            DataTable dta2 = new DataTable();


            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT id AS ID, descripcion AS DESCRIPCION, descripcion_adicional AS 'DESC. ADICIONAL', stock AS 'STOCK ACTUAL', stock_minimo AS 'STOCK MINIMO', ultimo_precio AS 'ULTIMO PRECIO' FROM articulo WHERE stock<=stock_minimo AND habilitado='SI'", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            da.Fill(dta1);

            MySqlConnection coon2 = Conexion.getConexion();
            MySqlCommand cm2 = new MySqlCommand("SELECT id AS ID, descripcion AS DESCRIPCION, descripcion_adicional AS 'DESC. ADICIONAL', stock AS 'STOCK ACTUAL', stock_puntopedir AS 'LIMITE A PEDIR', ultimo_precio AS 'ULTIMO PRECIO' FROM articulo WHERE stock>=stock_minimo AND stock<=stock_puntopedir AND habilitado='SI' ", coon);
            cm2.CommandType = CommandType.Text;
            cm2.ExecuteNonQuery();

            MySqlDataAdapter da2 = new MySqlDataAdapter(cm2);
            da2.Fill(dta2);




            GridView1.DataSource = dta1;
            GridView1.DataBind();
            ViewState["RECORD2"] = dta1;


            GridView2.DataSource = dta2;
            GridView2.DataBind();
            ViewState["RECORD3"] = dta2;



            coon.Close();

            if (GridView1.Rows.Count > 0)
            {
                Panel1.Visible = true;
            }

            if (GridView2.Rows.Count > 0)
            {
                Panel2.Visible = true;
            }

            if (Session["nombresistema"].ToString() == "DEPOSITO")
            {
                ideposito.Visible = true;
            }
            else
            {
                ideposito.Visible = false;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Deposito/VAlertas.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Deposito/VAlertas.aspx");
        }
    }
}
