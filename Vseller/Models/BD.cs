using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Vseller.Models
{
    public static class BD
    {
        public static string connectionString = "Server=.;Database=VsellerDB;Trusted_Connection=true;";

        public static SqlConnection Conectar()
        {
            SqlConnection Conn = new SqlConnection(connectionString);
            Conn.Open();
            return Conn;
        }

        public static void Desconectar(SqlConnection Conn)
        {
            Conn.Close();
        }


    }
}
