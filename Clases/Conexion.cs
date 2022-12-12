using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Integral_HPS
{
    public class Conexion
    {
        public void desconectar()
        {
            MySqlConnection coon = new MySqlConnection("server=localhost; port=3306; uid=root; pwd='Amoxi587'; database=hps_deposito;Convert Zero Datetime=True;");
            coon.Close();
        }
        public static MySqlConnection getConexion()
        {
            string c = "server=localhost; port=3306; uid=root; pwd='Amoxi587'; database=hps_deposito;Convert Zero Datetime=True;";
            MySqlConnection coon = new MySqlConnection(c);
            coon.Open();
            return coon;
        }
    }
}