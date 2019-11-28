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
            //xd
            ProductoDetalleProducto PDP = BD.TraerProductoCompleto(IdProd);

            ViewBag.Tipos = BD.TraerTipos(); 
            ViewBag.Detalles = PDP.Detalles;
            return View(PDP);
        }

        public ActionResult CargarProducto(int IdProd)
        {
            return View("editarProducto");
        }


        public ActionResult EliminarProducto(int id)
        {
            BD.EliminarProducto(id);
            return View("Index");
        }

        [HttpPost]
        public ActionResult Editar(ProductoDetalleProducto PDP)
        {
            if (PDP.foto != null)
            {
                string NuevaUbicacion = Server.MapPath("~/Content/") + PDP.foto.FileName;
                PDP.foto.SaveAs(NuevaUbicacion);
                PDP.nomFoto= PDP.foto.FileName;
            }
            Producto prod = new Producto(PDP.idProducto, PDP.fkTipo, PDP.nomFoto, PDP.nombre, PDP.precio, PDP.usuario);
            List<DatosProducto> Lista = PDP.Detalles;
            BD.EditarProducto(prod);
            for (int i = 0; i < Lista.Count; i++)
            {
                BD.EditarDetalle(Lista[i]);
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Crear(ProductoDetalleProducto PDP)
        {
            if (PDP.foto != null)
            {
                string NuevaUbicacion = Server.MapPath("~/Content/") + PDP.foto.FileName;
                PDP.foto.SaveAs(NuevaUbicacion);
                PDP.nomFoto = PDP.foto.FileName;
            }
            Producto prod = new Producto(PDP.idProducto, PDP.fkTipo, PDP.nomFoto, PDP.nombre, PDP.precio, PDP.usuario);
            List<DatosProducto> Lista = PDP.Detalles;
            BD.CargarProducto(prod);
            for (int i = 0; i < Lista.Count; i++)
            {
                BD.CrearDetalle(Lista[i]);
            }
            return View("Index");
        }


    }
}