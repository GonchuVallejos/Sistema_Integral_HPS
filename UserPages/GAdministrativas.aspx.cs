using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Integral_HPS.UserPages
{
    public partial class GAdministrativas : System.Web.UI.Page
    {
        MySqlConnection coon = Conexion.getConexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ASIGNA LAS DIRECCIONES
                MySqlCommand cm = new MySqlCommand("SELECT DISTINCT(descripcion) AS DIRECCION, id AS IDDIR FROM direccion ORDER BY descripcion;", coon);
                cm.CommandType = System.Data.CommandType.Text;

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);


                DropDownList1.DataValueField = "IDDIR";
                DropDownList1.DataTextField = "DIRECCION";
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();

                DropDownList2.DataValueField = "IDDIR";
                DropDownList2.DataTextField = "DIRECCION";
                DropDownList2.DataSource = dt;
                DropDownList2.DataBind();

                DropDownList3.DataValueField = "IDDIR";
                DropDownList3.DataTextField = "DIRECCION";
                DropDownList3.DataSource = dt;
                DropDownList3.DataBind();

                DropDownList5.DataValueField = "IDDIR";
                DropDownList5.DataTextField = "DIRECCION";
                DropDownList5.DataSource = dt;
                DropDownList5.DataBind();

                DropDownList1.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
                DropDownList2.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
                DropDownList3.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
                DropDownList5.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //INSERTA UN SERVICIO / DIVISION
            if ((DropDownList1.SelectedItem.Value != "SELECCIONE") && (TextBox1.Text != ""))
            {
                MySqlCommand cm = new MySqlCommand("INSERT INTO servicio_division(descripcion, fk_direccion) VALUES (UPPER('" + TextBox1.Text + "'), '" + DropDownList1.SelectedItem.Value + "')", coon);
                cm.CommandType = CommandType.Text;
                cm.ExecuteNonQuery();

                string msg = "SERVICIO/DIVISION REGISTRADO CORRECTAMENTE";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);

                TextBox1.Text = "";
                DropDownList1.Text = "SELECCIONE";
            }
            else
            {
                string msg = "REVISE LOS DATOS";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MySqlCommand cm = new MySqlCommand("SELECT servicio_division.id AS IDSD, servicio_division.fk_direccion AS IDD, servicio_division.descripcion AS 'SERVICIO/DIVISION', direccion.descripcion 'DIRECCION' FROM servicio_division INNER JOIN direccion ON servicio_division.fk_direccion = direccion.id WHERE servicio_division.descripcion LIKE '%" + TextBox2.Text + "%'", coon);
            cm.CommandType = CommandType.Text;

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();

            coon.Close();
            if (GridView1.Rows.Count != 0)
            {
                ViewState["CONSULTA"] = dt;
                GridView1.Visible = true;
            }
            else
            {
                string msg = "NO SE ENCUENTRAN SERVICIOS/DIVISIONES CON ESA DESCRIPCION";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
            }
            Panel1.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["CONSULTA"];
            MySqlCommand cm = new MySqlCommand("UPDATE servicio_division SET descripcion = UPPER('" + TextBox3.Text + "') WHERE id = '" + Session["IDSD"].ToString() + "'", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            string msg = "SERVICIO/DIVISION MODIFICADO CON ÉXITO";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);

            Panel1.Visible = false;
            TextBox2.Text = "";
            GridView1.Visible = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["CONSULTA"];

            DropDownList2.Text = dt.Rows[GridView1.SelectedIndex]["IDD"].ToString();
            TextBox3.Text = dt.Rows[GridView1.SelectedIndex]["SERVICIO/DIVISION"].ToString();

            Session["IDSD"] = dt.Rows[GridView1.SelectedIndex]["IDSD"].ToString();
            Panel1.Visible = true;

            TextBox3.Focus();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlCommand cm = new MySqlCommand("SELECT DISTINCT(descripcion) AS 'SERV/DIV', id AS IDSD FROM servicio_division WHERE fk_direccion = '" + DropDownList3.SelectedItem.Value + "' ORDER BY descripcion;", coon);
            cm.CommandType = System.Data.CommandType.Text;

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DropDownList4.DataValueField = "IDSD";
            DropDownList4.DataTextField = "SERV/DIV";
            DropDownList4.DataSource = dt;
            DropDownList4.DataBind();

            DropDownList4.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));

            DropDownList4.Focus();
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList4.Text != "SELECCIONE")
            {
                Label14.Visible = true;
                TextBox4.Visible = true;
                TextBox4.Focus();
            }
            else
            {
                Label14.Visible = false;
                TextBox4.Visible = false;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.Text != "SELECCIONE")
            {
                Label5.Visible = true;
                TextBox1.Visible = true;
                Button1.Visible = true;
                TextBox1.Focus();
            }
            else
            {
                Label5.Visible = false;
                TextBox1.Visible = false;
                Button1.Visible = false;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //INSERTA UNA UNIDAD / SECCION
            if ((DropDownList3.SelectedItem.Value != "SELECCIONE") && (DropDownList4.SelectedItem.Value != "SELECCIONE") && (TextBox4.Text != ""))
            {
                MySqlCommand cm = new MySqlCommand("INSERT INTO unidad_seccion(descripcion, fk_servicio_division) VALUES (UPPER('" + TextBox4.Text + "'), '" + DropDownList4.SelectedItem.Value + "')", coon);
                cm.CommandType = CommandType.Text;
                cm.ExecuteNonQuery();

                string msg = "UNIDAD/SECCION REGISTRADO CORRECTAMENTE";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);

                TextBox1.Text = "";
                DropDownList1.Text = "SELECCIONE";
            }
            else
            {
                string msg = "REVISE LOS DATOS";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            MySqlCommand cm = new MySqlCommand("SELECT unidad_seccion.id AS IDUS, unidad_seccion.fk_servicio_division AS IDSD, servicio_division.fk_direccion AS IDD, unidad_seccion.descripcion AS 'UNIDAD/SECCION', servicio_division.descripcion AS 'SERVICIO/DIVISION', direccion.descripcion 'DIRECCION' FROM unidad_seccion INNER JOIN servicio_division ON unidad_seccion.fk_servicio_division = servicio_division.id INNER JOIN direccion ON servicio_division.fk_direccion = direccion.id WHERE unidad_seccion.descripcion LIKE '%" + TextBox5.Text + "%'", coon);
            cm.CommandType = CommandType.Text;

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView2.DataSource = dt;
            GridView2.DataBind();

            coon.Close();
            if (GridView2.Rows.Count != 0)
            {
                ViewState["CONSULTAUS"] = dt;
                GridView2.Visible = true;

                MySqlCommand cm2 = new MySqlCommand("SELECT DISTINCT(descripcion) AS SERVICIO/DIVISION, id AS IDSD FROM servicio_division ORDER BY descripcion;", coon);
                cm.CommandType = System.Data.CommandType.Text;

                MySqlDataAdapter da2 = new MySqlDataAdapter(cm);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);


                DropDownList6.DataValueField = "IDSD";
                DropDownList6.DataTextField = "SERVICIO/DIVISION";
                DropDownList6.DataSource = dt2;
                DropDownList6.DataBind();

                DropDownList6.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
            }
            else
            {
                string msg = "NO SE ENCUENTRAN UNIDAD/SECCION CON ESA DESCRIPCION";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
            }
            Panel1.Visible = false;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["CONSULTAUS"];

            DropDownList5.Text = dt.Rows[GridView2.SelectedIndex]["IDSD"].ToString();
            DropDownList6.Text = dt.Rows[GridView2.SelectedIndex]["IDD"].ToString();
            TextBox6.Text = dt.Rows[GridView2.SelectedIndex]["UNIDAD/SECCION"].ToString();

            Session["IDUS"] = dt.Rows[GridView2.SelectedIndex]["IDUS"].ToString();
            Panel2.Visible = true;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["CONSULTAUS"];
            MySqlCommand cm = new MySqlCommand("UPDATE unidad_seccion SET descripcion = UPPER('" + TextBox6.Text + "') WHERE id = '" + Session["IDUS"].ToString() + "'", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            string msg = "UNIDAD/SECCION MODIFICADO CON ÉXITO";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);

            Panel2.Visible = false;
            TextBox6.Text = "";
            GridView2.Visible = false;
        }
    }
}