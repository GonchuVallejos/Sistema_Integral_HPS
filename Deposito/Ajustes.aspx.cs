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
    public partial class Ajustes : System.Web.UI.Page
    {
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
            MySqlCommand cm = new MySqlCommand("SELECT id,descripcion,descripcion_adicional,stock FROM articulo WHERE descripcion LIKE '%" + TextBox1.Text + "%' AND habilitado= 'SI'", coon);
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
            else
            {
                
            }
            coon.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label4.Visible = true;
            Label5.Visible = true;
            DropDownList1.Visible = true;
            TextBox2.Visible = true;
            Label7.Visible = true;
            Label6.Visible = true;
            Label6.Text = Convert.ToString(GridView1.SelectedRow.Cells[1].Text);
            Label8.Visible = true;
            TextBox3.Visible = true;
            Button2.Visible = true;

           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int idp = Convert.ToInt32(Session["usuariologgeado"].ToString());

            dt = (DataTable)ViewState["RECORD"];

            DataRow row = dt.NewRow();

            row["ID ARTICULO"] = Label6.Text;
            row["ARTICULO"] = Convert.ToString(GridView1.SelectedRow.Cells[2].Text); ;
            row["CANTIDAD"] = TextBox2.Text;

            dt.Rows.Add(row);
            dt.AcceptChanges();
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
    }
}