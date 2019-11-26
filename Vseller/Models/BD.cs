﻿
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
            bool Admin = false;
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

        public static List<Producto> TraerProductosPorTipo(int idTipo)
        {
            List<Producto> ListaProductos = new List<Producto>();
            Producto unProducto = new Producto();
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spTraerProductoPorTipo", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tipo", idTipo);
            SqlDataReader Lector = cmd.ExecuteReader();
            while (Lector.Read())
            {
                int Id = Convert.ToInt32(Lector["idProducto"]);
                int fk = Convert.ToInt32(Lector["fkTipo"]);
                string foto = Lector["Foto"].ToString();
                string nomb = Lector["Nombre"].ToString();
                int precio = Convert.ToInt32(Lector["Precio"]);
                unProducto = new Producto(Id, fk, foto, nomb, precio);
                ListaProductos.Add(unProducto);
            }
            Desconectar(Conexion);
            return ListaProductos;
        }
        public static Producto TraerProductoPorId(int id)
        {
            Producto unProducto = new Producto();
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spTraerProductoPorTipo", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader Lector = cmd.ExecuteReader();
            while (Lector.Read())
            {
                int Id = Convert.ToInt32(Lector["idProducto"]);
                int fk = Convert.ToInt32(Lector["fkTipo"]);
                string foto = Lector["Foto"].ToString();
                string nomb = Lector["Nombre"].ToString();
                int precio = Convert.ToInt32(Lector["Precio"]);
                Producto unProducto1 = new Producto(Id, fk, foto, nomb, precio);
                unProducto = unProducto1;
            }

            Desconectar(Conexion);
            return unProducto;
        }
        public static DatosProducto TraeDatosPorId(int id)
        {
            DatosProducto datos = new DatosProducto();
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spTraerDatosporId", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader Lector = cmd.ExecuteReader();
            while (Lector.Read())
            {
                /*int IdProd = Convert.ToInt32(Lector["idProducto"]);
                int fk = Convert.ToInt32(Lector["fkTipo"]);
                string foto = Lector["Foto"].ToString();
                
                Producto unProducto1 = new Producto(Id, fk, foto, nomb, precio);
                unProducto = unProducto1;
            }*/

            Desconectar(Conexion);
            return unProducto;
        }
    }
}
