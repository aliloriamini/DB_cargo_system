﻿using Cargo_system_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cargo_system_01.Controllers
{
    public class view_driverController : Controller
    {
        // GET: view_orders
        private Cargo_system01Entities3 db = new Cargo_system01Entities3();
        public ActionResult Index()
        {
            return View(db.View_driver);
        }
    }
}