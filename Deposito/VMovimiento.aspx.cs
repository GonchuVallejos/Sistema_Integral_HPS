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
    public partial class VMovimiento : System.Web.UI.Page
    {
        DataTable dta = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MySqlConnection coon = Conexion.getConexion();

                MySqlCommand cm2 = new MySqlCommand("SELECT id, descripcion FROM tipo_movimiento", coon);
                cm2.CommandType = System.Data.CommandType.Text;

                MySqlDataAdapter da1 = new MySqlDataAdapter(cm2);
                DataTable dt = new DataTable();
                da1.Fill(dt);

                DropDownList1.DataValueField = "id";
                DropDownList1.DataTextField = "descripcion";
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();
                
            }
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            DataTable dta1 = (DataTable)ViewState["RECORD2"];
            DataTable dta2 = new DataTable();
            //DataTable dta1 = new DataTable();
            MySqlConnection coon = Conexion.getConexion();
            ////
            //MySqlCommand cm = new MySqlCommand("SELECT fk_tipo_movimiento FROM movimiento", coon);            cm.CommandType = CommandType.Text;
            //cm.ExecuteNonQuery();
            //MySqlDataAdapter dat1 = new MySqlDataAdapter(cm);
            //Convert.ToString(GridView1.SelectedRow.Cells[7].Text)
            
            int idm = Convert.ToInt32(GridView1.SelectedRow.Cells[8].Text);
            if (idm ==1003)
            {
                int idp= Convert.ToInt32(GridView1.SelectedRow.Cells[6].Text);
                MySqlCommand cm1 = new MySqlCommand("SELECT detalle_pedido.fk_articulo AS 'ID ARTICULO',detalle_pedido.cantidad AS 'CANTIDAD',articulo.descripcion AS 'ARTICULO',detalle_pedido.observacion AS 'OBSERVACION' FROM detalle_pedido INNER JOIN articulo  ON detalle_pedido.fk_articulo=articulo.id WHERE detalle_pedido.fk_pedido='" + idp +"' GROUP BY detalle_pedido.fk_articulo", coon);
                MySqlDataAdapter da = new MySqlDataAdapter(cm1);
                da.Fill(dta2);
                GridView2.DataSource = dta2;
                GridView2.DataBind();
              //  ViewState["RECORD2"] = dta1;
            }
            if (idm == 1005 || idm==1006)
            {
                int idp = Convert.ToInt32(GridView1.SelectedRow.Cells[7].Text);
                MySqlCommand cm1 = new MySqlCommand("SELECT detalle_ajuste.fk_articulo AS 'ID ARTICULO',detalle_ajuste.cantidad AS 'CANTIDAD',articulo.descripcion AS 'ARTICULO',detalle_ajuste.tipo_ajuste,detalle_ajuste.observacion AS 'OBSERVACION' FROM detalle_ajuste INNER JOIN articulo ON detalle_ajuste.fk_articulo=articulo.id WHERE fk_ajuste='" + idp + "' GROUP BY detalle_ajuste.fk_articulo", coon); 
                MySqlDataAdapter da = new MySqlDataAdapter(cm1);
                da.Fill(dta2);
                GridView2.DataSource = dta2;
                GridView2.DataBind();
               // ViewState["RECORD2"] = dta1;
            }
            if (idm == 1001)
            {
                int idp = Convert.ToInt32(GridView1.SelectedRow.Cells[9].Text);
                MySqlCommand cm1 = new MySqlCommand("SELECT detalle_adquisicion.fk_articulo AS 'ID ARTICULO',detalle_adquisicion.cantidad AS 'CANTIDAD',articulo.descripcion AS 'ARTICULO',detalle_adquisicion.observacion AS 'OBSERVACION' FROM detalle_adquisicion INNER JOIN articulo ON detalle_adquisicion.fk_articulo=articulo.id WHERE fk_adquisicion='" + idp + "' GROUP BY detalle_adquisicion.fk_articulo", coon);
                MySqlDataAdapter da = new MySqlDataAdapter(cm1);
                da.Fill(dta2);
                GridView2.DataSource = dta2;
                GridView2.DataBind();
                //ViewState["RECORD2"] = dta1;
            }



            coon.Close();
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;

            MySqlConnection coon = Conexion.getConexion();

            MySqlCommand cm = new MySqlCommand("SELECT movimiento.id AS id_movimiento, CONCAT(persona.nombre, ' ', persona.apellido) AS usuario, estado, fecha_alta, observacion, fk_pedido,fk_adquisicion,fk_ajuste, fk_tipo_movimiento FROM movimiento INNER JOIN usuario ON movimiento.fk_usuario = usuario.id INNER JOIN persona ON usuario.fk_persona = persona.id WHERE fk_tipo_movimiento = '" + DropDownList1.SelectedValue + "'  ", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            da.Fill(dta);

            GridView1.DataSource = dta;

            ViewState["RECORD2"] = dta;
            GridView1.DataBind();
          
            coon.Close();
            GridView2.DataSource = null;
            GridView2.DataBind();
        }
    }
}