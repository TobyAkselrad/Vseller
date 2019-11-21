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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logueo(Usuario user)
        {            
            bool Existe;
            bool Admin;
            Admin = BD.TraerAdmin(user);
            if (ModelState.IsValid)
            {
                Existe = BD.ExisteUsuario(user);
                if (Existe)
                {
                    if (Admin == false) {
                        return View("Index");
                    }

                    else {
                        return RedirectToAction("Index", "BackOffice");
                    }
                }
                else
                {
                    ViewBag.Error = "Nombre o usuario incorrectos";
                    return View("Login", user);
                }
            }
            else
            {
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
            }
            else
            {
                BD.CargarUsuario(user);
            }
            return View("Registro");
        }


        public ActionResult Registro()
        {
            return Index();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Labura Fede";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}