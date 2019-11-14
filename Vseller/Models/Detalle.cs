using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vseller.Models
{
    public class Detalle
    {
        private int _idDetalle;
        private string _desc;

        public int IdDetalle { get => _idDetalle; set => _idDetalle = value; }
        public string Desc { get => _desc; set => _desc = value; }

        public Detalle()
        {

        }

        public Detalle(int a,string b)
        {
            _idDetalle = a;
            _desc = b;
        }
    }
}