using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Integral_HPS.Deposito
{
    public partial class MasterDeposito : System.Web.UI.MasterPage
    {
        MySqlConnection coon = Conexion.getConexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id;
            string usuario;
            //if (!IsPostBack)
            //{
            //    if (Session["usuario"] != null)
            //    {
            //        id = Session["usuariologgeado"].ToString();
            //        usuario = Session["usuario"].ToString();

            //        Label1.Text = usuario;
            //    }
            //    else
            //    {
            //        Response.Redirect("/UserPages/Login.aspx");
            //    }
            //}


            if (Session["usuario"] != null)
            {
                id = Session["usuariologgeado"].ToString();
                usuario = Session["usuario"].ToString();

                Label1.Text = usuario;

                MySqlCommand cm = new MySqlCommand("SELECT * FROM servicio_division WHERE id = '" + Session["servicio_division"].ToString() + "'", coon);
                cm.CommandType = CommandType.Text;
                MySqlDataReader dr = cm.ExecuteReader();

                dr.Read();
                switch (dr["descripcion"].ToString())
                {
                    case "DEPOSITO":
                        {
                            deposito.Visible = true;
                            todosusuarios.Visible = false;
                            sesion.Visible = true;
                        }
                        break;
                    default:
                        {
                            todosusuarios.Visible = true;
                            deposito.Visible = false;
                            sesion.Visible = true;
                        }
                        break;
                }
                dr.Close();

            }
            else
            {
                Response.Redirect("/UserPages/Login.aspx");
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("/UserPages/Login.aspx");

            //PRUEBA DE SUBIDA
        }
    }
}