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
        public ActionResult Login(Usuario user)
        {
            
            bool Existe;
            if (ModelState.IsValid)
            {
                Existe = BD.ExisteUsuario(user);
                if (Existe)
                {
                    
                    return View("Index");
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