using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Integral_HPS.Deposito
{
    public partial class CPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label3.Visible = false;
            Label4.Visible = false;
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            DropDownList2.Visible = false;
            DropDownList3.Visible = false;
            DropDownList4.Visible = false;
            DropDownList5.Visible = false;
            DropDownList6.Visible = false;

            TextBox1.Text = TextBox2.Text = "";

            if (DropDownList1.SelectedItem.Value != "SELECCIONE")
            {
                switch (DropDownList1.SelectedItem.Value)
                {
                    case ("ID PEDIDO"):
                        {
                            //CARGA PARA CONSULTAR SI ES CAJA CHICA O PROVISON
                            DropDownList2.Visible = true;
                            DropDownList2.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
                            DropDownList2.Items.Insert(1, new ListItem("PEDIDOS CAJA CHICA", "pedido_provision"));
                            DropDownList2.Items.Insert(2, new ListItem("PEDIDOS PROVISION", "pedido"));

                            Label3.Text = "ID DE PEDIDO";
                            Label3.Visible = true;
                            TextBox1.Visible = true;
                            TextBox1.TextMode = TextBoxMode.Number;
                        }
                        break;
                    case ("FECHA"):
                        {
                            Label3.Text = "FECHA DE INICIO";
                            Label3.Visible = true;
                            TextBox1.Visible = true;
                            TextBox1.TextMode = TextBoxMode.Date;

                            Label4.Text = "FECHA DE FIN";
                            Label4.Visible = true;
                            TextBox2.Visible = true;
                            TextBox2.TextMode = TextBoxMode.Date;

                            //CARGA PARA CONSULTAR SI ES CAJA CHICA O PROVISON
                            DropDownList5.Visible = true;
                            DropDownList5.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
                            DropDownList5.Items.Insert(1, new ListItem("PEDIDOS CAJA CHICA", "pedido_provision"));
                            DropDownList5.Items.Insert(2, new ListItem("PEDIDOS PROVISION", "pedido"));

                            DropDownList6.Visible = true;
                            DropDownList6.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
                            DropDownList6.Items.Insert(1, new ListItem("CONFIRMADO", "CONFIRMADO"));
                            DropDownList6.Items.Insert(2, new ListItem("PENDIENTE", "PENDIENTE"));
                        }
                        break;
                    case ("USUARIO ESPECIFICO"):
                        {
                            //AGREGAR SQL PARA TRAER USUARIOS EN EL DDL2
                            MySqlConnection coon = Conexion.getConexion();
                            DataTable dt = new DataTable();

                            MySqlCommand cm = new MySqlCommand("SELECT usuario.id AS idusuario CONCAT(persona.apellido,' ', persona.nombre) AS llenar FROM usuario INNER JOIN persona ON usuario.fk_persona = persona.id WHERE fk_servicio_division = '" + Session["servicio_division"].ToString() + "'", coon);
                            cm.CommandType = System.Data.CommandType.Text;

                            MySqlDataAdapter da = new MySqlDataAdapter(cm);
                            da.Fill(dt);

                            DropDownList2.DataValueField = "idusuario";
                            DropDownList2.DataTextField = "llenar";
                            DropDownList2.DataSource = dt;
                            DropDownList2.DataBind();

                            //CARGA PARA CONSULTAR SI ES CAJA CHICA O PROVISON
                            DropDownList3.Visible = true;
                            DropDownList3.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
                            DropDownList3.Items.Insert(1, new ListItem("PEDIDOS CAJA CHICA", "pedido_provision"));
                            DropDownList3.Items.Insert(2, new ListItem("PEDIDOS PROVISION", "pedido"));

                            //CARGA ESTADO DE PEDIDOS
                            DropDownList4.Visible = true;
                            DropDownList4.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
                            DropDownList4.Items.Insert(1, new ListItem("CONFIRMADO", "CONFIRMADO"));
                            DropDownList4.Items.Insert(2, new ListItem("PENDIENTE", "PENDIENTE"));
                        }
                        break;
                    default:
                        {
                            //CARGA PARA CONSULTAR SI ES CAJA CHICA O PROVISON
                            DropDownList2.Visible = true;
                            DropDownList2.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
                            DropDownList2.Items.Insert(1, new ListItem("PEDIDOS CAJA CHICA", "pedido_provision"));
                            DropDownList2.Items.Insert(2, new ListItem("PEDIDOS PROVISION", "pedido"));

                            //CARGA ESTADO DE PEDIDOS
                            DropDownList3.Visible = true;
                            DropDownList3.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
                            DropDownList3.Items.Insert(1, new ListItem("CONFIRMADO", "CONFIRMADO"));
                            DropDownList3.Items.Insert(2, new ListItem("PENDIENTE", "PENDIENTE"));

                        }
                        break;
                }
            }
            else
            {
                string msg = "DEBE SELECCIONAR UN PARAMETRO DE BUSQUEDA PARA CONTINUAR";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlConnection coon = Conexion.getConexion();

            string consulta;

            switch (DropDownList1.SelectedItem.Value)
            {
                case ("ID PEDIDO"):
                    {
                        consulta = "SELECT (" + DropDownList2.SelectedItem.Value + ").id AS IDPEDIDO, CONCAT(persona.nombre, ' ', persona.apellido) AS 'NOMBRE Y APELLIDO', servicio_division.descripcion AS DESCRIPCION, (" + DropDownList2.SelectedItem.Value + ").fecha AS FECHA FROM (" + DropDownList2.SelectedItem.Value + ") INNER JOIN usuario ON (" + DropDownList2.SelectedItem.Value + ").fk_usuario = usuario.id INNER JOIN servicio_division ON usuario.fk_servicio_division = servicio_division.id INNER JOIN persona ON usuario.fk_persona = persona.id WHERE (" + DropDownList2.SelectedItem.Value + ").id = '" + TextBox1.Text + "'";
                    }
                    break;
                case ("FECHA"):
                    {
                        consulta = "SELECT (" + DropDownList5.SelectedItem.Value + ").id AS IDPEDIDO, CONCAT(persona.nombre, ' ', persona.apellido) AS 'NOMBRE Y APELLIDO', servicio_division.descripcion AS DESCRIPCION, (" + DropDownList5.SelectedItem.Value + ").fecha AS FECHA FROM (" + DropDownList5.SelectedItem.Value + ") INNER JOIN usuario ON (" + DropDownList5.SelectedItem.Value + ").fk_usuario = usuario.id INNER JOIN servicio_division ON usuario.fk_servicio_division = servicio_division.id INNER JOIN persona ON usuario.fk_persona = persona.id WHERE (" + DropDownList5.SelectedItem.Value + ").fecha BETWEEN '" + TextBox1.Text + "' AND '" + TextBox2.Text + "' AND (" + DropDownList5.SelectedItem.Value + ").estado = (" + DropDownList6.SelectedItem.Value + ")";
                    }
                    break;
                case ("USUARIO ESPECIFICO"):
                    {
                        consulta = "SELECT (" + DropDownList3.SelectedItem.Value + ").id AS IDPEDIDO, CONCAT(persona.nombre, ' ', persona.apellido) AS 'NOMBRE Y APELLIDO', servicio_division.descripcion AS DESCRIPCION, (" + DropDownList3.SelectedItem.Value + ").fecha AS FECHA FROM (" + DropDownList3.SelectedItem.Value + ") INNER JOIN usuario ON (" + DropDownList3.SelectedItem.Value + ").fk_usuario = usuario.id INNER JOIN servicio_division ON usuario.fk_servicio_division = servicio_division.id INNER JOIN persona ON usuario.fk_persona = persona.id WHERE (" + DropDownList3.SelectedItem.Value + ").fk_usuario = '" + DropDownList2.SelectedItem.Value + "' and (" + DropDownList3.SelectedItem.Value + ").estado = '" + DropDownList4.SelectedItem.Value + "'";
                    }
                    break;
                default:
                    {
                        consulta = "SELECT (" + DropDownList2.SelectedItem.Value + ").id AS IDPEDIDO, CONCAT(persona.nombre, ' ', persona.apellido) AS 'NOMBRE Y APELLIDO', servicio_division.descripcion AS DESCRIPCION, (" + DropDownList2.SelectedItem.Value + ").fecha AS FECHA FROM (" + DropDownList2.SelectedItem.Value + ") INNER JOIN usuario ON (" + DropDownList2.SelectedItem.Value + ").fk_usuario = usuario.id INNER JOIN servicio_division ON usuario.fk_servicio_division = servicio_division.id INNER JOIN persona ON usuario.fk_persona = persona.id WHERE (" + DropDownList2.SelectedItem.Value + ").id = '" + DropDownList3.SelectedItem.Value + "'";
                    }
                    break;
            }

            MySqlCommand cm = new MySqlCommand(consulta, coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
            ViewState["RECORD"] = dt;
            coon.Close();
        }
    }
}