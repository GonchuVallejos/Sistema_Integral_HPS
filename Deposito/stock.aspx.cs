using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
//Ver stock id, nombre y por familia
namespace Sistema_Integral_HPS
{
    public partial class stock : System.Web.UI.Page
    {
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
            MySqlCommand cm = new MySqlCommand("SELECT * FROM `familia`", coon);
          
            cm.CommandType = System.Data.CommandType.Text;
           

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

           

            DropDownList2.DataValueField = "id";
            DropDownList2.DataTextField = "descripcion";
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();

            coon.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT id,descripcion,stock FROM articulo WHERE descripcion LIKE '%" + TextBox1.Text + "%' AND habilitado= 'SI'", coon);
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.Text.Equals("NOMBRE"))
            {
                Label3.Visible = true;
                TextBox1.Visible = true;
                GridView1.Visible = true;
            }
            if (DropDownList1.Text.Equals("FAMILIA"))
            {
                Label3.Visible = false;
                TextBox1.Visible = false;
                GridView1.Visible = false;
            }
            if (DropDownList1.Text.Equals("ID"))
            {
                Label3.Visible = false;
                TextBox1.Visible = false;
                GridView1.Visible = false;
            }
        }
        protected void DropDonList1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_PreRender(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT id,descripcion,stock FROM articulo WHERE fk_familias= '"  + DropDownList2.SelectedValue + "' AND habilitado= 'SI'", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT id,descripcion,stock FROM articulo WHERE id= '" + TextBox2.Text + "' AND habilitado= 'SI'", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Text.Equals("NOMBRE"))
            {
                Label3.Visible = true;
                TextBox1.Visible = true;
                GridView1.Visible = true;
                Button1.Visible= true;

                DropDownList2.Visible = false;
                Label4.Visible = false;
                Button2.Visible = false;

                Label5.Visible = false;
                TextBox2.Visible = false;
                Button3.Visible= false;
            }
            if (DropDownList1.Text.Equals("FAMILIA"))
            {

                Label4.Visible = true;
                DropDownList2.Visible = true;
                Button2.Visible = true;
                GridView1.Visible = true;
                Button1.Visible = false;

                Label3.Visible = false;
                TextBox1.Visible = false;

                Label5.Visible = false;
                TextBox2.Visible = false;
                Button3.Visible = false;
            }
            if (DropDownList1.Text.Equals("ID"))
            {

                Label5.Visible = true;
                TextBox2.Visible = true;
                Button3.Visible = true;
                GridView1.Visible = true;
                Button1.Visible = false;

                Label3.Visible = false;
                TextBox1.Visible = false;

                DropDownList2.Visible = false;
                Label4.Visible = false;
                Button2.Visible = false;
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}