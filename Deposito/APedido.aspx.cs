using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

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
                //MessageBox.Show("¡NO EXISTE ARTICULO !");
            }
            coon.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox2.Visible = true;
            Button2.Visible = true;
            string idv = GridView1.SelectedDataKey.Value.ToString();
            Label1.Text = Convert.ToString(idv);
            Label2.Visible = true;
            Label2.Text = Convert.ToString(GridView1.SelectedRow.Cells[2].Text);
        }

        protected void Button2_Click(object sender, EventArgs e)
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
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("INSERT INTO detalle_pedido(id,fk_pedido,fk_articulo,cantidad,observacion) VALUES (NULL,'1000001','" + Label1.Text + "','" + TextBox2.Text + "','')", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();
            coon.Close();
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
            dt.Rows[row.DataItemIndex]["CANTIDAD"] = ((TextBox)(row.Cells[2].Controls[0])).Text;

            GridView2.EditIndex = -1;

            Session["RECORD"] = dt;

            GridView2.DataSource = dt;
            GridView2.DataBind();
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
    }
}