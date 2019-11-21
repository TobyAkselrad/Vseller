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
        private string _img;

        public int Id { get => _id; set => _id = value; }
        public string Desc { get => _desc; set => _desc = value; }
        public string Img { get => _img; set => _img = value; }

        public tipo()
        { }
        public tipo(int a,string b, string c)
        {
            _id = a;
            _desc = b;
            _img = c;
        }

    }
}