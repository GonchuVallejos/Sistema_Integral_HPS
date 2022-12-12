using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Integral_HPS.UserPages
{
    public partial class RUsuarios : System.Web.UI.Page
    {
        MySqlConnection coon = Conexion.getConexion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // ASIGNA LAS PROVINCIAS
                MySqlCommand cm = new MySqlCommand("SELECT DISTINCT(provincia) AS PROVINCIA FROM localizaciones ORDER BY provincia;", coon);
                cm.CommandType = System.Data.CommandType.Text;

                MySqlDataAdapter da = new MySqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);


                DropDownList2.DataValueField = "PROVINCIA";
                DropDownList2.DataTextField = "PROVINCIA";
                DropDownList2.DataSource = dt;
                DropDownList2.DataBind();

                DropDownList2.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));


                //ASIGNA LAS DIRECCIONES
                MySqlCommand cm2 = new MySqlCommand("SELECT DISTINCT(descripcion) AS DIRECCION, id AS IDDIR FROM direccion ORDER BY descripcion;", coon);
                cm2.CommandType = System.Data.CommandType.Text;

                MySqlDataAdapter da2 = new MySqlDataAdapter(cm2);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);


                DropDownList5.DataValueField = "IDDIR";
                DropDownList5.DataTextField = "DIRECCION";
                DropDownList5.DataSource = dt2;
                DropDownList5.DataBind();

                DropDownList5.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));

                coon.Close();
            }
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownList5.SelectedItem.Text)
            {
                case "SELECCIONE":
                    {
                        Panel3.Visible = false;
                        Panel4.Visible = false;
                    }
                    break;
                default:
                    {
                        if (DropDownList5.SelectedItem.Text == "MÉDICA")
                        {
                            Label21.Text = "PERSONAL DE SALUD";
                        }
                        else
                        {
                            Label21.Text = "PERSONAL ADMINISTRATIVO";
                        }


                        MySqlCommand cm = new MySqlCommand("SELECT DISTINCT(descripcion) AS SERVDIV, id AS IDSERV FROM servicio_division WHERE fk_direccion = '" + DropDownList5.SelectedItem.Value.ToString() + "' ORDER BY descripcion;", coon);
                        cm.CommandType = System.Data.CommandType.Text;

                        MySqlDataAdapter da = new MySqlDataAdapter(cm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        DropDownList6.DataValueField = "IDSERV";
                        DropDownList6.DataTextField = "SERVDIV";
                        DropDownList6.DataSource = dt;
                        DropDownList6.DataBind();

                        DropDownList6.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
                    }
                    break;
            }
            DropDownList6.Focus();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlCommand cm = new MySqlCommand("SELECT DISTINCT(departamento) AS DEPARTAMENTO FROM localizaciones WHERE provincia = '" + DropDownList2.SelectedItem.Value.ToString() + "' ORDER BY departamento;", coon);
            cm.CommandType = System.Data.CommandType.Text;

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DropDownList3.DataValueField = "DEPARTAMENTO";
            DropDownList3.DataTextField = "DEPARTAMENTO";
            DropDownList3.DataSource = dt;
            DropDownList3.DataBind();

            DropDownList3.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
            DropDownList3.Focus();
            coon.Close();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlCommand cm = new MySqlCommand("SELECT DISTINCT(localidad) AS LOCALIDAD, id AS IDLOC FROM localizaciones WHERE departamento = '" + DropDownList3.SelectedItem.Value.ToString() + "' ORDER BY localidad;", coon);
            cm.CommandType = System.Data.CommandType.Text;

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DropDownList4.DataValueField = "IDLOC";
            DropDownList4.DataTextField = "LOCALIDAD";
            DropDownList4.DataSource = dt;
            DropDownList4.DataBind();

            DropDownList4.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
            DropDownList4.Focus();
            coon.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string domicilio = "";

            if (TextBox6.Text.Length != 0)
            {
                domicilio = TextBox6.Text;
                if (TextBox7.Text.Length != 0)
                {
                    domicilio = domicilio + " N° " + TextBox7.Text;
                }
                if (TextBox8.Text.Length != 0)
                {
                    domicilio = domicilio + " PISO " + TextBox8.Text;
                }
                if (TextBox9.Text.Length != 0)
                {
                    domicilio = domicilio + " DPTO " + TextBox9.Text;
                }
                if (TextBox17.Text.Length != 0)
                {
                    domicilio = domicilio + " - B° " + TextBox17.Text;
                }
            }

            if (TextBox14.Text.Length != 0)
            {
                domicilio = "MZA " + TextBox14.Text;
                if (TextBox15.Text.Length != 0)
                {
                    domicilio = domicilio + " LOTE " + TextBox15.Text;
                }
                if (TextBox16.Text.Length != 0)
                {
                    domicilio = domicilio + " CASA " + TextBox16.Text;
                }
                if (TextBox17.Text.Length != 0)
                {
                    domicilio = domicilio + " - B° " + TextBox17.Text;
                }
            }

            //INSERTA LA PERSONA
            MySqlCommand cm = new MySqlCommand("INSERT INTO persona(apellido, nombre, tipo_doc, dni, domicilio, fk_localizacion, fecha_nac, sexo, email, telefono) VALUES ('" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + DropDownList14.SelectedItem.Value + "', '" + TextBox13.Text + "', '" + domicilio + "', '" + DropDownList4.SelectedItem.Value + "', '" + TextBox4.Text + "', '" + DropDownList1.SelectedItem.Value + "', '" + TextBox3.Text + "', '" + TextBox5.Text + "')", coon);
            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MySqlCommand cm2 = new MySqlCommand("SELECT * FROM persona WHERE dni = '" + TextBox13.Text + "'", coon);
            cm2.CommandType = CommandType.Text;
            MySqlDataReader dr = cm2.ExecuteReader();

            dr.Read();

            //INSERTA EL USUARIO
            using (MySqlCommand cmd = new MySqlCommand("insertar_usuario", coon))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("NUSUARIO", MySqlDbType.VarChar).Value = TextBox13.Text;
                cmd.Parameters.Add("CONTRASEÑA", MySqlDbType.VarChar).Value = TextBox13.Text;
                cmd.Parameters.Add("FK_PERSONA", MySqlDbType.VarChar).Value = dr["id"].ToString();
                cmd.Parameters.Add("FK_DIRECCION", MySqlDbType.VarChar).Value = DropDownList5.SelectedItem.Value;
                cmd.Parameters.Add("FK_SERVICIO_DIVISION", MySqlDbType.VarChar).Value = DropDownList6.SelectedItem.Value;
                cmd.Parameters.Add("FK_UNIDAD_SECCION", MySqlDbType.VarChar).Value = DropDownList7.SelectedItem.Value;
                cmd.Parameters.Add("FK_ROL", MySqlDbType.VarChar).Value = DropDownList13.SelectedItem.Value;
                cmd.Parameters.Add("USUARIOCREA", MySqlDbType.VarChar).Value = Session["usuariologgeado"].ToString();
                dr.Close();
                cmd.ExecuteNonQuery();
            }

            MySqlCommand cm3 = new MySqlCommand("SELECT MAS(id) AS idus FROM usuario", coon);
            cm2.CommandType = CommandType.Text;
            MySqlDataReader dr2 = cm2.ExecuteReader();

            dr2.Read();

            string consulta;

            //INSERTA EN PERSONAL O PROFESIONAL
            switch (DropDownList5.SelectedItem.Value)
            {
                case ("MÉDICA"):
                    {
                        consulta = ("INSERT INTO profesional(prefijo, fk_usuario, fk_especialidad, matricula, legajo, puesto, titulo, situacion_revista) VALUES (" + DropDownList9.SelectedItem.Value + ", " + dr2["idus"].ToString() + ", " + DropDownList10.SelectedItem.Value + ", " + TextBox10.Text + ", " + TextBox11.Text + ", " + DropDownList8.SelectedItem.Value + ", " + TextBox12.Text + ", " + DropDownList11.SelectedItem.Value + ");");
                    }
                    break;
                case ("ADMINISTRATIVA"):
                    {
                        consulta = ("INSERT INTO personal(prefijo, fk_usuario, fk_especialidad, matricula, legajo, puesto, titulo, situacion_revista) VALUES (" + DropDownList9.SelectedItem.Value + ", " + dr2["idus"].ToString() + ", " + DropDownList10.SelectedItem.Value + ", " + TextBox10.Text + ", " + TextBox11.Text + ", " + DropDownList8.SelectedItem.Value + ", " + TextBox12.Text + ", " + DropDownList11.SelectedItem.Value + ");");
                    }
                    break;
                default:
                    {
                        consulta = "";
                    }
                    break;
            }

            dr.Close();

            MySqlCommand cm4 = new MySqlCommand(consulta, coon);
            cm4.CommandType = CommandType.Text;
            cm4.ExecuteNonQuery();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //VOLVER AL INDEX
        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlCommand cm = new MySqlCommand("SELECT DISTINCT(descripcion) AS UNISEC, id AS IDUNI FROM unidad_seccion WHERE fk_servicio_division = '" + DropDownList6.SelectedItem.Value.ToString() + "' ORDER BY descripcion;", coon);
            cm.CommandType = System.Data.CommandType.Text;

            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DropDownList7.DataValueField = "IDUNI";
            DropDownList7.DataTextField = "UNISEC";
            DropDownList7.DataSource = dt;
            DropDownList7.DataBind();

            DropDownList7.Items.Insert(0, new ListItem("SELECCIONE", "SELECCIONE"));
            DropDownList7.Focus();

            coon.Close();
        }

        protected void DropDownList9_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel4.Visible = true;
            //DropDownList10.Focus();
            Button1.Focus();
        }

        protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            DropDownList9.Focus();
        }

        protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList8.Focus();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if ((DropDownList14.SelectedItem.Value != "SELECCIONE") && (TextBox13.Text != "") && ((TextBox13.Text.Length == 7) || (TextBox13.Text.Length == 8)))
            {
                MySqlCommand cm = new MySqlCommand("SELECT * FROM persona WHERE dni = '" + TextBox13.Text + "'", coon);
                cm.CommandType = CommandType.Text;
                MySqlDataReader dr = cm.ExecuteReader();

                if (!dr.Read())
                {
                    Panel5.Visible = true;
                }
                else
                {
                    Panel5.Visible = false;
                    string msg = "EL DNI YA SE ENCUENTRA REGISTRADO";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
                }
            }
            else
            {
                Panel5.Visible = false;
                string msg = "SELECCIONE/INGRESE DATOS VALIDOS";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('" + msg + "');", true);
            }
        }
    }
}