using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data.SqlClient;

namespace Sistema_Integral_HPS.ABM
{
    public class Conexion
    {
        public void conectar()
        {
            MySqlConnection coon = new MySqlConnection("server=localhost; port=3306; uid=root; pwd=''; database=test;");
            coon.Open();
        }

        public void desconectar()
        {
            MySqlConnection coon = new MySqlConnection("server=localhost; port=3306; uid=root; pwd=''; database=test;");
            coon.Close();
        }


    }
}