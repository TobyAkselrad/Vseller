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

        public static bool ExisteUsuario(Usuario user)
        {
            bool Existe;
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("sp_VerificarUsuario", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", user.Username);
            cmd.Parameters.AddWithValue("@contraseña", user.Contraseña);
            cmd.Parameters.AddWithValue("@adm", user.Admin);

            SqlDataReader Lector = cmd.ExecuteReader();
            if (Lector.Read())
            {
                Existe = true;
            }
            else
            {
                Existe = false;
            }
            Desconectar(Conexion);
            return Existe;
        }
    }
}
