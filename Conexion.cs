﻿using MySql.Data.MySqlClient;
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
            MySqlConnection coon = new MySqlConnection("server=localhost; port=3306; uid=root; pwd=''; database=test;");
            coon.Close();
        }
        public static MySqlConnection getConexion()
        {
            string c = "server=localhost; port=3306; uid=root; pwd=''; database=test;";
            MySqlConnection coon = new MySqlConnection(c);
            coon.Open();
            return coon;
        }
    }
}