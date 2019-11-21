
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Vseller.Models
{
    public static class BD
    {
        public static string connectionString = "Server=.;Database=VsellerDB;user id=alumno; password=alumno1;";

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
            SqlCommand cmd = new SqlCommand("spSelectUsuario", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@password", user.Contraseña);

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

        public static bool ExisteUsername(Usuario user)
        {
            bool Existe;
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spValidarUsuario", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User", user.Username);

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
        
        public static bool TraerAdmin(Usuario user)
        {
            bool Admin=false;
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spTraerAdmin", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@password", user.Contraseña);

            SqlDataReader Lector = cmd.ExecuteReader();
            if (Lector.Read())
            {
                Admin = Convert.ToBoolean(Lector["Admin"]);
            }         
            Desconectar(Conexion);
            return Admin;
        }
        public static void CargarProducto(Producto prod)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spCargarProducto", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fkTipo", prod.FkTipo);
            cmd.Parameters.AddWithValue("@Foto", prod.NomFoto);
            cmd.Parameters.AddWithValue("@Nombre", prod.Nombre);
            cmd.Parameters.AddWithValue("@Precio", prod.Precio);
            SqlDataReader Lector = cmd.ExecuteReader();
            Desconectar(Conexion);
        }
        public static void CargarUsuario(Usuario user)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spCargarUsuario", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@password", user.Contraseña);
            SqlDataReader Lector = cmd.ExecuteReader();
            Desconectar(Conexion);
        }

        public static List<tipo> TraerTipos()
        {
            List<tipo> ListaTipos = new List<tipo>();
            tipo unTipo = new tipo();
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spTraerTipos", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader Lector = cmd.ExecuteReader();
            while (Lector.Read())
            {
                int Id = Convert.ToInt32(Lector["idTipo"]);
                string Desc = Lector["Descripcion"].ToString();
                string Img = Lector["Imagen"].ToString();
                unTipo = new tipo(Id, Desc, Img);
                ListaTipos.Add(unTipo);
            }
            Desconectar(Conexion);
            return ListaTipos;
        }
    }
}
