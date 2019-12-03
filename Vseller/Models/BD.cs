
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
            cmd.Parameters.AddWithValue("@Tipo", prod.FkTipo);
            cmd.Parameters.AddWithValue("@Foto", prod.NomFoto);
            cmd.Parameters.AddWithValue("@Nombre", prod.Nombre);
            cmd.Parameters.AddWithValue("@Precio", prod.Precio);
            cmd.Parameters.AddWithValue("@Usuario", prod.Usuario);
            SqlDataReader Lector = cmd.ExecuteReader();
            Desconectar(Conexion);
        }
        public static void CargarUsuario(Usuario user)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spCargarUsuario", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nom", user.Nombre);
            cmd.Parameters.AddWithValue("@user", user.Username);
            cmd.Parameters.AddWithValue("@pass", user.Contraseña);
            cmd.Parameters.AddWithValue("@adm", 0);
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
                string Usuario = Lector["fkUsuario"].ToString();
                unProducto = new Producto(Id, fk, foto, nomb, precio,Usuario);
                ListaProductos.Add(unProducto);
            }
            Desconectar(Conexion);
            return ListaProductos;
        }
        public static Producto TraerProductoPorId(int id)
        {
            Producto unProducto = new Producto();
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spTraerProductoPorId", Conexion);
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
                string Usuario = Lector["fkUsuario"].ToString();
                Producto unProducto1 = new Producto(Id, fk, foto, nomb, precio, Usuario);
                unProducto = unProducto1;
            }

            Desconectar(Conexion);
            return unProducto;
        }
        public static List<DatosProducto> TraeDatosPorId(int id)
        {
            List<DatosProducto> Lista = new List<DatosProducto>();
            DatosProducto datos1 = new DatosProducto();
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spTraerDatosporId", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProd", id);
            SqlDataReader Lector = cmd.ExecuteReader();
            while (Lector.Read())
            {
                string deta= Lector["Descripcion"].ToString();
                int fkProducto = Convert.ToInt32(Lector["fkProducto"]);
                int fkDetalle = Convert.ToInt32(Lector["fkDetalle"]);

                datos1 = new DatosProducto(fkProducto, fkDetalle, deta);
                Lista.Add(datos1);
            }

            Desconectar(Conexion);
            return Lista;
        }

        public static void EliminarProducto(int idProd)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand cma = new SqlCommand("spEliminarProducto", Conexion);
            cma.CommandType = System.Data.CommandType.StoredProcedure;
            cma.Parameters.AddWithValue("@id", idProd);
            SqlDataReader Lector1 = cma.ExecuteReader();
            Desconectar(Conexion);
        }

        public static void EliminarDatos(int idProd)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spEliminarDatos", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", idProd);
            SqlDataReader Lector = cmd.ExecuteReader();
            EliminarProducto(idProd);
             Desconectar(Conexion);
        }


        public static List<Detalle> TraerDetalle()
        {
            List<Detalle> ListDetalles = new List<Detalle>();            
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spTraerDetalles", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader Lector = cmd.ExecuteReader();
            while (Lector.Read())
            {
                string desc = Lector["Descripción"].ToString();
                int idDetalle = Convert.ToInt32(Lector["idDetalle"]);                

                Detalle unDetalle = new Detalle(idDetalle,desc);
                ListDetalles.Add(unDetalle);
            }

            Desconectar(Conexion);
            return ListDetalles;
        }


        public static Detalle TraerDetalleporId(int Id)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spTraerDetallesxId>", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", Id);
            SqlDataReader Lector = cmd.ExecuteReader();

            Detalle unDetalle = new Detalle();
            while (Lector.Read())
            {
                string desc = Lector["Descripción"].ToString();
                int idDetalle = Convert.ToInt32(Lector["idDetalle"]);
                unDetalle = new Detalle(idDetalle, desc);
            }

            Desconectar(Conexion);
            return unDetalle;
        }

        public static ProductoDetalleProducto TraerProductoCompleto(int idProducto)
        {

            Producto prod = TraerProductoPorId(idProducto);
            List<DatosProducto> dato = TraeDatosPorId(idProducto);

            ProductoDetalleProducto PDP = new ProductoDetalleProducto();
            PDP.idProducto = prod.IdProducto;
            PDP.fkTipo = prod.FkTipo;
            PDP.nombre = prod.Nombre;
            PDP.nomFoto = prod.NomFoto;
            PDP.precio = prod.Precio;
            PDP.usuario = prod.Usuario;
            PDP.Detalles = dato;

            return PDP;
        }

        public static void EditarDetalle (DatosProducto dato)
        {
                SqlConnection Conexion = Conectar();
                SqlCommand cmd = new SqlCommand("spEditarDescDetalle", Conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Prod", dato.fkProducto);
                cmd.Parameters.AddWithValue("@Det", dato.fkDetalle);
                cmd.Parameters.AddWithValue("@Desc",dato.descripcion);                
                SqlDataReader Lector = cmd.ExecuteReader();
                Desconectar(Conexion);            
        }

        public static void EditarProducto(Producto prod)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spspEditarProducto", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", prod.IdProducto);
            cmd.Parameters.AddWithValue("@Tipo", prod.FkTipo);
            cmd.Parameters.AddWithValue("@Foto", prod.NomFoto);
            cmd.Parameters.AddWithValue("@Nombre", prod.Nombre);
            cmd.Parameters.AddWithValue("@Precio", prod.Precio);
            cmd.Parameters.AddWithValue("@Usuario", prod.Usuario);
            SqlDataReader Lector = cmd.ExecuteReader();
            Desconectar(Conexion);
        }

        public static void CrearDetalle(DatosProducto dato)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand cmd = new SqlCommand("spCargarDatosProducto", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Produc", dato.fkProducto);
            cmd.Parameters.AddWithValue("@Detalle", dato.fkDetalle);
            cmd.Parameters.AddWithValue("@Desc", dato.descripcion);
            SqlDataReader Lector = cmd.ExecuteReader();
            Desconectar(Conexion);
        }

    }
}
