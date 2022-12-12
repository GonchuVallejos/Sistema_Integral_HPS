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
    public partial class UPass : System.Web.UI.Page
    {
        MySqlConnection coon = Conexion.getConexion();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "")
            {
                if (TextBox1.Text != TextBox2.Text)
                {
                    if (TextBox2.Text == TextBox3.Text)
                    {
                        MySqlCommand cm = new MySqlCommand("SELECT * FROM usuario WHERE usuario.id = '" + Session["usuariologgeado"].ToString() + "' AND (AES_DECRYPT(usuario.contraseña, 'HOLA') = '" + TextBox1.Text + "') ", coon);
                        cm.CommandType = CommandType.Text;

                        MySqlDataReader dr = cm.ExecuteReader();

                        if (dr.Read())
                        {
                            MySqlCommand cm1 = new MySqlCommand("UPDATE usuario SET usuario.contraseña = AES_ENCRYPT('" + TextBox2.Text + "', 'HOLA') WHERE usuario.id = '" + Session["usuariologgeado"].ToString() + "'", coon);
                            cm1.CommandType = CommandType.Text;
                            cm1.ExecuteNonQuery();
                        }
                        else
                        {
                            string msg = "LA CONTRASEÑA INGRESADA NO SE CORRESPONDE CON EL USUARIO";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
                        }
                    }
                    else
                    {
                        string msg = "LAS CONTRASEÑAS NO COINCIDEN";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
                    }
                }
                else
                {
                    string msg = "DEBE INGRESAR UNA CONTRASEÑA DISTINTA A LA ACTUAL";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
                }
            }
            else
            {
                string msg = "DEBE COMPLETAR TODOS LOS CAMPOS";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
            }
        }
    }
}