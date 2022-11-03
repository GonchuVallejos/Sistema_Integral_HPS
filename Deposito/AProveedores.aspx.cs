using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
//Buscar proveedor 
//Registrar el nombre de los proveedores si no existen
namespace Sistema_Integral_HPS.Deposito.Reportes
{
    public partial class AProveedores : System.Web.UI.Page
    {
        DataTable dta = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MySqlConnection coon1 = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT proveedor.descripcion as 'NOMBRE PROVEEDOR', cuit_cuil as 'CUIT CUIL', domicilio as 'DOMICILIO', usuario.nusuario as 'USUARIO QUE DIO DE ALTA', proveedor.fecha_alta as 'FECHA ALTA' FROM proveedor INNER JOIN usuario ON proveedor.fk_usuario=usuario.id WHERE proveedor.descripcion LIKE '%" + TextBox1.Text + "%'", coon1);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            //DataTable dt = new DataTable();
            da.Fill(dta);

            GridView1.DataSource = dta;
            GridView1.DataBind();

            if (GridView1.Rows.Count != 0)
            {
               


            }
            else
            {
                Label5.Visible = false;
                TextBox1.Visible = false;
                Button2.Visible = false;
                Button1.Visible = true;
                Label4.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = null ;
            id = Session["usuariologgeado"].ToString();
            MySqlConnection coon = Conexion.getConexion(); // AQUI EMPIEZO A GUARDAR LA "CABECERA DE ADQUISICION" DIGAMOS ALGO PARECIDO A PEDIDO Y DETALLE DE PEDIDO
            MySqlCommand cm1 = new MySqlCommand("INSERT INTO proveedor(id,descripcion,cuit_cuil,domicilio,fk_usuario) VALUES (NULL,'" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "', '" + id + "')", coon);
            cm1.CommandType = CommandType.Text;
            cm1.ExecuteNonQuery();
            MessageBox.Show("PROVEEDOR CARGADO CORRECTAMENTE! ");
            Response.Redirect("IndexDeposito.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}