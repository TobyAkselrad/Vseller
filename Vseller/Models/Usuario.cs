﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vseller.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "Ingrese contraseña")]
        public string Contraseña { get; set; }

        [Required(ErrorMessage = "Ingrese nombre de usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Ingrese nombre")]
        public string Nombre { get; set; }
        public bool Admin { get; set; }

        public Usuario()
        {

        }

        public Usuario(string nom, string con, string user,bool adm)
        {
            Nombre = nom;
            Contraseña = con;
            Username = user;
            Admin = adm;
        }
    }
}