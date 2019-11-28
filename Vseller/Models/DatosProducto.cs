using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vseller.Models
{
    public class DatosProducto
    {
        private int _fkProducto;
        private int _fkDetalle;
        private string _descripcion;

        public int fkProducto { get => _fkProducto; set => _fkProducto = value; }
        public int fkDetalle { get => _fkDetalle; set => _fkDetalle = value; }
        public string descripcion { get => _descripcion; set => _descripcion = value; }

        public DatosProducto(int a, int b, string c)
        {
            _fkProducto = a;
            _fkDetalle = b;
            _descripcion = c;
        }

        public DatosProducto()
        {

        }
    }
}