using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Sistema_Integral_HPS.UserPages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection coon = Conexion.getConexion();
            using (MySqlCommand cmd = new MySqlCommand("sesion", coon))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("NUSUARIO", MySqlDbType.VarChar).Value = TextBox1.Text;
                cmd.Parameters.Add("CONTRASEÑA", MySqlDbType.VarChar).Value = TextBox2.Text;
                 MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Session["usuariologgeado"] = dr["id"].ToString();
                    Session["direccion"] = dr["fk_direccion"].ToString();
                    Session["servicio_division"] = Convert.ToInt16(dr["fk_servicio_division"].ToString());
                    Session["unidad_seccion"] = Convert.ToInt16(dr["fk_unidad_seccion"].ToString());
                    using (MySqlCommand cm = new MySqlCommand("recupera_usuario", coon))
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.Add("ID", MySqlDbType.VarChar).Value = dr["fk_persona"].ToString();
                        dr.Close();
                        MySqlDataReader usuario = cm.ExecuteReader();
                        if (usuario.Read())
                        {
                            Session["usuario"] = usuario["nombre"].ToString() + " " + usuario["apellido"].ToString();

                        }
                        usuario.Close();
                    }

                    //SACO EL NOMBRE DEL SERVICIO AL QUE PERTENECE EL USUARIO PARA VER QUE SISTEMA MOSTRAR
                    MySqlCommand cm2 = new MySqlCommand("SELECT * FROM servicio_division WHERE id = '" + Session["servicio_division"].ToString() + "'", coon);
                    cm2.CommandType = CommandType.Text;
                    MySqlDataReader dr2 = cm2.ExecuteReader();

                    dr2.Read();
                    Session["nombresistema"] = dr2["descripcion"].ToString();
                    dr2.Close();

                    Response.Redirect("~/Index.aspx");

                }
                else
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";

                    string msg = "Usuario o contraseña incorrecto";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg +"');", true);
                }
                coon.Close();
            }
        }
    }
}