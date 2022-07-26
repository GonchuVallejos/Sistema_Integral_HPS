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


namespace Sistema_Integral_HPS.ABM
{
    public partial class Alta_articulo : System.Web.UI.Page
    {
        Conexion cn = new Conexion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { LlenarDrop(); }

        }

        protected void LlenarDrop()
        {

            // cn.conectar();
            //MySqlConnection coon = new MySqlConnection("server=localhost; port=3306; uid=root; pwd=''; database=test;");
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT * FROM `familia`",coon);
            MySqlCommand cm1 = new MySqlCommand("SELECT * FROM `unidad_medida`",coon);
            MySqlCommand cm2 = new MySqlCommand("SELECT * FROM `deposito`",coon);
            cm.CommandType = System.Data.CommandType.Text;
            cm1.CommandType = System.Data.CommandType.Text;
            cm2.CommandType = System.Data.CommandType.Text;

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            MySqlDataAdapter da1 = new MySqlDataAdapter(cm1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            MySqlDataAdapter da2 = new MySqlDataAdapter(cm2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            DropDownList1.DataValueField = "id";
            DropDownList1.DataTextField = "descripcion";
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();


            DropDownList2.DataValueField = "id";
            DropDownList2.DataTextField = "descripcion";
            DropDownList2.DataSource = dt1;
            DropDownList2.DataBind();


            DropDownList3.DataValueField = "id";
            DropDownList3.DataTextField = "descripcion";
            DropDownList3.DataSource = dt2;
            DropDownList3.DataBind();

            cn.desconectar();
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
             //  cn.conectar();
               MySqlCommand cm = new MySqlCommand("INSERT INTO articulo (descripcion,descripcion_adicional,fk_familias,fk_unimedidas,stock,fk_desposito,stock_maximo,stock_minimo,stock_puntopedir,inventareable,habilitado,ultimo_precio) VALUES ('" + TextBox1.Text + "'),'" + TextBox2.Text + "','" + Convert.ToInt32(DropDownList1.SelectedValue) + "','" + Convert.ToInt32(DropDownList2.SelectedValue) + "','" + Convert.ToInt32(DropDownList3.SelectedValue) + "','" + TextBox3.Text + "','" + TextBox4.Text+ "')");
               cm.CommandType = System.Data.CommandType.Text;
               cm.ExecuteNonQuery();
              
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {

        }

    }
}