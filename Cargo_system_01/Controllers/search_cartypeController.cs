using Cargo_system_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cargo_system_01.Controllers
{
    public class search_cartypeController : Controller
    {
        // GET: search_cartype
        private Cargo_system01Entities3 db = new Cargo_system01Entities3();
        public ActionResult Indexes()
        {
            ViewBag.cartypes = new SelectList(db.cartypes, "cartype_id", "name");

            return View(db.View_driver);
        }
        [HttpPost]
        public ActionResult Index(int id)
        {

            //if (Request.Form["text"] == null)  
            //{  
            //    TempData["SelectOption"] = -1;  
            //}             
            ViewBag.cartypes = new SelectList(db.cartypes, "cartype_id", "name");
                return View(db.sp_cartype(id));

        }
    }
}