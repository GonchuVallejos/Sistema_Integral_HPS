﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using iTextSharp.tool.xml.html;
using System.Threading;
//Alta de los pedidos
//Seleccionar y agregar al detalle del pedido 
namespace Sistema_Integral_HPS.Deposito
{
    public partial class APedido : System.Web.UI.Page
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
            
            GridView1.Visible = true;
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT id,descripcion,descripcion_adicional FROM articulo WHERE descripcion LIKE '%" + TextBox1.Text + "%' AND habilitado= 'SI'", coon);
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
                Label6.Visible = true;
               Label6.Text = "SELECCIONAR ARTICULO";
                Panel1.Visible = true;
                Label4.Visible = false;
                TextBox2.Visible = false;
                Button2.Visible = false;
            }
            coon.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox2.Visible = true;
            Button2.Visible = true;
            Label4.Visible = true;
            string idv = GridView1.SelectedDataKey.Value.ToString();
            Label1.Text = Convert.ToString(idv);
            Label2.Visible = true;
            Label2.Text =Convert.ToString(GridView1.SelectedRow.Cells[2].Text);
            GridView1.Visible = false;
           Label6.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int valor;
            bool isNum = int.TryParse(TextBox2.Text, out valor);

            if ((isNum == true) && (valor >= 1))
            {

                dt = (DataTable)ViewState["RECORD"];

                DataRow row = dt.NewRow();

                row["ID ARTICULO"] = Label1.Text;
                row["ARTICULO"] = Label2.Text;
                row["CANTIDAD"] = TextBox2.Text;

                dt.Rows.Add(row);
                dt.AcceptChanges();
                GridView2.DataSource = dt;
                GridView2.DataBind();
                //LIMPIA LOS TEXT BOX DE ARTICULO Y CANTIDAD

                TextBox1.Text = null;
                TextBox2.Text = " ";
                Label6.Visible = false;
                Label2.Visible = false;

                Button5.Visible = true;
                Label4.Visible = false;
                TextBox2.Visible = false;
                Button2.Visible = false;

                Label7.Visible = false;
                TextBox1.Visible = false;
                Button1.Visible = false;
            }
            else
            {
                string msg = ("DEBE INGRESAR UNA CANTIDAD VALIDA");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            dt = (DataTable)ViewState["RECORD"];
            if (dt.Rows.Count != 0)
            {
                int idp = Convert.ToInt32(Session["usuariologgeado"].ToString());
                string dir = Session["direccion"].ToString();
                int serdiv = Convert.ToInt32(Session["servicio_division"].ToString());
                int unisec = Convert.ToInt32(Session["unidad_seccion"].ToString());

                MySqlConnection coon = Conexion.getConexion();
                MySqlCommand cm1 = new MySqlCommand("INSERT INTO pedido(id,fk_usuario, direccion, servicio_division, unidad_seccion) VALUES (NULL,'" + idp + "', '" + dir + "', '" + serdiv + "', '" + unisec + "')", coon);
                cm1.CommandType = CommandType.Text;
                cm1.ExecuteNonQuery();

                MySqlCommand cm2 = new MySqlCommand("SELECT MAX(id) FROM pedido", coon);
                cm2.CommandType = System.Data.CommandType.Text;

                MySqlDataAdapter da = new MySqlDataAdapter(cm2);
                DataTable dt2 = new DataTable();
                da.Fill(dt2);

                int idped = Convert.ToInt32(dt2.Rows[0].ItemArray.GetValue(0).ToString());



                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int ida = Convert.ToInt32(dt.Rows[i]["ID ARTICULO"].ToString());
                    int cant = Convert.ToInt32(dt.Rows[i]["CANTIDAD"].ToString());
                    MySqlCommand cm = new MySqlCommand("INSERT INTO detalle_pedido(id,fk_pedido,fk_articulo,cantidad,observacion) VALUES (NULL,'" + idped + "','" + ida + "','" + cant + "','')", coon);
                    cm.CommandType = CommandType.Text;
                    cm.ExecuteNonQuery();

                }




                coon.Close();

                string msg = ("PEDIDO ID " + idped + " REALIZADO");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "'); window.location = 'Index.aspx';", true);

                //Response.Redirect("/Deposito/IndexDeposito.aspx");
            }
            else
            {
                string msg = ("NO SOLICITO NINGÚN ARTICULO");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dt = (DataTable)ViewState["RECORD"];
            dt.Rows.RemoveAt(e.RowIndex);

            Session["RECORD"] = dt;

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["RECORD"];

            GridViewRow row = GridView2.Rows[e.RowIndex];

            int valor;

            bool isNum = int.TryParse(((TextBox)(row.Cells[2].Controls[0])).Text, out valor);

            if ((isNum == true) && (valor >= 1))
            {
                dt.Rows[row.DataItemIndex]["CANTIDAD"] = ((TextBox)(row.Cells[2].Controls[0])).Text;

                GridView2.EditIndex = -1;

                Session["RECORD"] = dt;

                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                string msg = ("DEBE INGRESAR UNA CANTIDAD VALIDA");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
            }
            
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;

            dt = (DataTable)ViewState["RECORD"];
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;

            dt = (DataTable)ViewState["RECORD"];
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Index.aspx");
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Label4.Visible = false;
            TextBox2.Visible = false;
            Button2.Visible = false;
            Button5.Visible = false;

            Label7.Visible = true;
            TextBox1.Visible = true;
            Button1.Visible = true;
        }
    }
}