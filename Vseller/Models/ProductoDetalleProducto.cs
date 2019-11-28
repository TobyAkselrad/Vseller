using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vseller.Models
{
    public class ProductoDetalleProducto
    {
        public int idProducto { get; set; }
        public int fkTipo { get; set; }
        public HttpPostedFileBase foto { get; set; }
        public string nomFoto { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
        public string usuario { get; set; }
        public List<DatosProducto> Detalles = new List<DatosProducto>();



        public ProductoDetalleProducto()
        {

        }

        
    }
}