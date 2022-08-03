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

namespace Sistema_Integral_HPS.UserPages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string patron = "HPS";
            MySqlConnection coon = Conexion.getConexion();
            using (MySqlCommand cmd = new MySqlCommand("sesion", coon))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("NUSUARIO", MySqlDbType.VarChar).Value = TextBox1.Text;
                cmd.Parameters.Add("CONTRASEÑA", MySqlDbType.VarChar).Value = TextBox2.Text;
                cmd.Parameters.Add("PATRON", MySqlDbType.VarChar).Value = patron;
                MySqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    Session["sesion"] = dr;
                    Session["usuariologgeado"] = dr["id"].ToString();
                    Session["idpersona"] = dr["idp"].ToString();
                    Response.Redirect("LLEVA A LA PANTALLA PRINCIPAL");
                }
                else
                {
                    //PONER EL CUADRO DE USUARIO INEXISTENTE
                }
                coon.Close();
            }
        }
    }
}