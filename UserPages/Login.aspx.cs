﻿using System;
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
                    }

                    Response.Redirect("/Deposito/IndexDeposito.aspx");

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