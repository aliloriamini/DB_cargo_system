using Cargo_system_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cargo_system_01.Controllers
{
    public class search_orders_customerController : Controller
    {
        private Cargo_system01Entities3 db = new Cargo_system01Entities3();
        // GET: search_orders_customer
        public ActionResult Indexes()
        {
            ViewBag.customers = new SelectList(db.customers, "customer_id", "name");

            return View(db.View_orders);
        }
        [HttpPost]
        public ActionResult Index(int id)
        {

            //if (Request.Form["text"] == null)  
            //{  
            //    TempData["SelectOption"] = -1;  
            //}             
            ViewBag.customers = new SelectList(db.customers, "customer_id", "name");
            return View(db.sp_orders_customer(id));
        }
    }
}