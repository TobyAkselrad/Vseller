using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vseller.Models
{
    public class tipo
    {
        private int _id;
        private string _desc;

        public int Id { get => _id; set => _id = value; }
        public string Desc { get => _desc; set => _desc = value; }

        public tipo()
        { }
        public tipo(int a,string b)
        {
            _id = a;
            _desc = b;
        }

    }
}