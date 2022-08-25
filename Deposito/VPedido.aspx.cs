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
	public partial class VPedido : System.Web.UI.Page
	{
        DataTable dt = new DataTable();
        string id;
        
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                DataTable dta = new DataTable();
                MySqlConnection coon = Conexion.getConexion();
                MySqlCommand cm = new MySqlCommand("SELECT pedido.id, CONCAT(persona.nombre, ' ', persona.apellido) AS 'NOMBRE Y APELLIDO', servicio_division.descripcion, pedido.fecha FROM pedido INNER JOIN usuario ON pedido.fk_usuario = usuario.id INNER JOIN servicio_division ON usuario.fk_servicio_division = servicio_division.id INNER JOIN persona ON usuario.fk_persona = persona.id WHERE estado = 'PENDIENTE'", coon);
                cm.CommandType = CommandType.Text;
                cm.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                da.Fill(dta);

                GridView1.DataSource = dta;
                GridView1.DataBind();
                ViewState["RECORD"] = dt;
                coon.Close();
            }
           
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dta1 = new DataTable();
            Panel2.Visible = true;
            Panel1.Visible = true;
            TextBox1.Text = Convert.ToString(GridView1.SelectedRow.Cells[2].Text); 
            TextBox2.Text = Convert.ToString(GridView1.SelectedRow.Cells[4].Text);
            
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT detalle_pedido.id as iddetalle, detalle_pedido.fk_pedido as idpedido, detalle_pedido.fk_articulo,articulo.descripcion,detalle_pedido.cantidad,unidad_medida.descripcion AS unidad_medida,detalle_pedido.observacion FROM detalle_pedido INNER JOIN articulo ON detalle_pedido.fk_articulo = articulo.id INNER JOIN unidad_medida ON articulo.fk_unimedidas=unidad_medida.id INNER JOIN pedido ON detalle_pedido.fk_pedido='" + Convert.ToString(GridView1.SelectedRow.Cells[1].Text) + "'GROUP BY detalle_pedido.fk_articulo", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            da.Fill(dta1);
            GridView2.DataSource = dta1;
            GridView2.DataBind();
            ViewState["RECORD2"] = dta1;
            coon.Close();

            Panel2.Visible = true;
        }
        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dta1 = (DataTable)ViewState["RECORD2"];

            GridViewRow row = GridView2.Rows[e.RowIndex];
            dta1.Rows[row.DataItemIndex]["CANTIDAD"] = ((TextBox)(row.Cells[3].Controls[0])).Text;
            dta1.Rows[row.DataItemIndex]["OBSERVACION"] = ((TextBox)(row.Cells[5].Controls[0])).Text;

            GridView2.EditIndex = -1;

            Session["RECORD2"] = dta1;

            GridView2.DataSource = dta1;
            GridView2.DataBind();

            btn_guardar.Visible = true;
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;

            DataTable dta1 = (DataTable)ViewState["RECORD2"];
            GridView2.DataSource = dta1;
            GridView2.DataBind();

            btn_guardar.Visible = false;
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;

            DataTable dta1 = (DataTable)ViewState["RECORD2"];
            GridView2.DataSource = dta1;
            GridView2.DataBind();

            btn_guardar.Visible = true;
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Deposito/IndexDeposito.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            MySqlConnection coon = Conexion.getConexion();

            DataTable dta1 = (DataTable)ViewState["RECORD2"];

            for (int i = 0; i < dta1.Rows.Count; i++)
            {
                //SE MODIFICA LA CANTIDAD SOLICITADA Y SE AGREGA LA OBSERVACION DE PORQUE SE MODIFICA
                MySqlCommand cm = new MySqlCommand("UPDATE detalle_pedido SET detalle_pedido.cantidad = '" + dta1.Rows[i]["CANTIDAD"].ToString() + "', detalle_pedido.observacion = '" + dta1.Rows[i]["OBSERVACION"].ToString() + "' WHERE id = '" + dta1.Rows[i]["iddetalle"].ToString() + "';", coon);
                cm.CommandType = CommandType.Text;
                cm.ExecuteNonQuery();

                //SE ACTUALIZA EL STOCK DE ARTICULOS, RESTANDO EL ACTUAL MENOS LO SUMINISTRADO
                MySqlCommand cm3 = new MySqlCommand("UPDATE articulo SET stock = stock - '" + Convert.ToInt16(dta1.Rows[i]["CANTIDAD"].ToString()) + "' WHERE id = '" + Convert.ToInt16(dta1.Rows[i]["fk_articulo"].ToString()) + "'", coon);
                cm3.CommandType = CommandType.Text;
                cm3.ExecuteNonQuery();
            }

            id = Session["usuariologgeado"].ToString();

            //SE ACTUALIZA EL ESTADO DEL PEDIDO A CONFIRMADO
            MySqlCommand cm2 = new MySqlCommand("UPDATE pedido SET estado = 'CONFIRMADO' WHERE id = '" + dta1.Rows[0]["idpedido"].ToString() + "'", coon);
            cm2.CommandType = CommandType.Text;
            cm2.ExecuteNonQuery();

            //SE INSERTA EL MOVIMIENTO
            MySqlCommand cm1 = new MySqlCommand("INSERT INTO movimiento (id, fk_tipo_movimiento, fk_pedido, fk_adquisicion, fk_ajuste, fk_usuario, estado) VALUES (NULL, 1003, '" + dta1.Rows[0]["idpedido"].ToString() + "', NULL, NULL, '" + id + "','CONFIRMADO')", coon);
            cm1.CommandType = CommandType.Text;
            cm1.ExecuteNonQuery();

            coon.Close();
            Response.Redirect("/Deposito/IndexDeposito.aspx");
        }

    }
}