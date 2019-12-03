using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vseller.Models;
using System.ComponentModel.DataAnnotations;

namespace Vseller.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index1()
        {
            ViewBag.id = "";
            bool Registrado = false;
            ViewBag.Registrado = Registrado;
            return View("Index");
        }

        public ActionResult Index()
        {
        return View("Index");
        }
        [HttpPost]
        public ActionResult Logueo(Usuario user)
        {
            bool Existe;
            bool Admin;
            bool Registrado = false;
            Admin = BD.TraerAdmin(user);
            Existe = BD.ExisteUsuario(user);
            if (Existe)
            {
                if (Admin == false)
                {
                    Registrado = true;
                    ViewBag.Registrado = Registrado;
                    ViewBag.User = user;
                    return View("Index");
                }

                else
                {
                    return RedirectToAction("Index", "BackOffice");
                }
            }
            else
            {
                ViewBag.Error = "Nombre o usuario incorrectos";
                return View("Login", user);
            }
        }

        public ActionResult Login ()
        {
            return View();
        }

        public ActionResult Registrado(Usuario user)
        {
            bool existe;
            existe = BD.ExisteUsername(user);
            if (existe)
            {
                ViewBag.Error = "Nombre de usuario ya existente";
                return View("Registro");
            }
            else
            {
                BD.CargarUsuario(user);
                return View("Index");
            }
        }

        public ActionResult CerrarSesión()
        {
            bool Registrado = false;
            ViewBag.Registrado = Registrado;
            return View("Index");
        }


        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Busqueda()
        {
            bool Registrado = false;
            ViewBag.Registrado = Registrado;
            return View();
        }

        public ActionResult Busqueda1()
        {
            return View("Busqueda");
        }

    }
}