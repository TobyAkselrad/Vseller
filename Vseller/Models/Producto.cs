using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vseller.Models
{
    public class Producto
    {
        private int _idProducto;
        private int _fkTipo;
        private string _nomFoto;
        private HttpPostedFileBase foto;
        private string _nombre;
        private int _precio;
        private string _usario;

        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public int FkTipo { get => _fkTipo; set => _fkTipo = value; }
        public string NomFoto { get => _nomFoto; set => _nomFoto = value; }
        public HttpPostedFileBase Foto { get => foto; set => foto = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Precio { get => _precio; set => _precio = value; }
        public string Usario { get => _usario; set => _usario = value; }

        public Producto()
        {

        }

        public Producto(int id, int fkTipo, string nameFoto, string nom, int pre)
        {
            _idProducto = id;
            _fkTipo = fkTipo;
            _nomFoto = nameFoto;
            _nombre = nom;
            _precio = pre;
        }
    }
}