﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace Sistema_Integral_HPS.Deposito
{
    public partial class AArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDrop();
            }
        }
        protected void LlenarDrop()
        {
            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT * FROM `familia`", coon);
            MySqlCommand cm1 = new MySqlCommand("SELECT * FROM `unidad_medida`", coon);
            MySqlCommand cm2 = new MySqlCommand("SELECT * FROM `deposito`", coon);
            cm.CommandType = System.Data.CommandType.Text;
            cm1.CommandType = System.Data.CommandType.Text;
            cm2.CommandType = System.Data.CommandType.Text;

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            MySqlDataAdapter da1 = new MySqlDataAdapter(cm1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            MySqlDataAdapter da2 = new MySqlDataAdapter(cm2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            DropDownList1.DataValueField = "id";
            DropDownList1.DataTextField = "descripcion";
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();


            DropDownList2.DataValueField = "id";
            DropDownList2.DataTextField = "descripcion";
            DropDownList2.DataSource = dt1;
            DropDownList2.DataBind();


            DropDownList3.DataValueField = "id";
            DropDownList3.DataTextField = "descripcion";
            DropDownList3.DataSource = dt2;
            DropDownList3.DataBind();

            coon.Close();
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {

            MySqlConnection coon = Conexion.getConexion();
            MySqlCommand cm = new MySqlCommand("SELECT COUNT(*) FROM articulo WHERE descripcion = '" + TextBox1.Text + "'", coon);
            cm.CommandType = System.Data.CommandType.Text;

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows[0].ItemArray.GetValue(0).ToString() == "0")
            {
                MySqlCommand cm2 = new MySqlCommand("INSERT INTO articulo (id,descripcion,descripcion_adicional,fk_familias,fk_unimedidas,stock,fk_deposito,stock_minimo,stock_maximo,stock_puntopedir,inventariable,habilitado,ultimo_precio) VALUES (NULL,'" + TextBox1.Text + "','" + TextBox2.Text + "','" + Convert.ToInt32(DropDownList1.SelectedValue) + "','" + Convert.ToInt32(DropDownList2.SelectedValue) + "','','" + Convert.ToInt32(DropDownList3.SelectedValue) + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + DropDownList4.SelectedValue + "','" + DropDownList5.SelectedValue + "','" + Convert.ToDouble(TextBox7.Text) + "')", coon);
                cm2.CommandType = System.Data.CommandType.Text;
                cm2.ExecuteNonQuery();
            }
            coon.Close();
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {

        }
    }
}