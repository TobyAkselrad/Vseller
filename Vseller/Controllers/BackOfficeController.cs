﻿using System;
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
            return View();
        }

        

    }
}