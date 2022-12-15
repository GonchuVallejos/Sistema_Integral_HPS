﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Integral_HPS
{
    public partial class MasterSistemaIntegralSoria : System.Web.UI.MasterPage
    {
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


                switch (Session["nombresistema"].ToString())
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
                            //superusuario.Visible = true;
                        }
                        break;
                }
            }
            else
            {
                Response.Redirect("~/UserPages/Login.aspx");
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("~/UserPages/Login.aspx");
        }
    }
}