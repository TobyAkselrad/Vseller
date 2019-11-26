using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vseller.Models;
using System.ComponentModel.DataAnnotations;

namespace Vseller.Controllers
{
    public class BackOfficeController : Controller
    {
        // GET: BackOffice
        public ActionResult Index()
        {
            List<tipo> ListaTipos = new List<tipo>();
            ListaTipos = BD.TraerTipos();
            ViewBag.Tipos = ListaTipos;
            return View();
        }

        public ActionResult ProductosxTipo(int IdTipoProd)
        {
            List<Producto> ListaProductos = new List<Producto>();
            ListaProductos = BD.TraerProductosPorTipo(IdTipoProd);
            ViewBag.Lista = ListaProductos;
            return View();
        }

        public ActionResult editarProducto(int IdProd)
        {
            Producto unProducto = BD.TraerProductoPorId(IdProd);
            DatosProducto datos = BD.TraeDatosPorId(IdProd);
            return View();
        }


    }
}