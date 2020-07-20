using Cargo_system_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cargo_system_01.Controllers
{
    public class search_order_statusController : Controller
    {
        private Cargo_system01Entities3 db = new Cargo_system01Entities3();

        // GET: search_order_status
        public ActionResult Indexes()
        {
            //this.ViewData["loadstatus"] = db.loadstatus.ToList();
            ViewBag.loadstatus = new SelectList(db.loadstatus, "loadstatus_id", "name");

            return View(db.View_orders);
        }

        [HttpPost]
        public ActionResult Index(int id)
        {

            //if (Request.Form["text"] == null)  
            //{  
            //    TempData["SelectOption"] = -1;  
            //}             
            ViewBag.loadstatus = new SelectList(db.loadstatus, "loadstatus_id", "name");
            return View(db.sp_orders_status(id));
        }
    }
}