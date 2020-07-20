using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cargo_system_01.Models;

namespace Cargo_system_01.Controllers
{
    public class carpropertiesController : Controller
    {
        private Cargo_system01Entities3 db = new Cargo_system01Entities3();

        // GET: carproperties
        public ActionResult Index()
        {
            return View(db.carproperties.ToList());
        }

        // GET: carproperties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carproperty carproperty = db.carproperties.Find(id);
            if (carproperty == null)
            {
                return HttpNotFound();
            }
            return View(carproperty);
        }

        // GET: carproperties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: carproperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "carproperty_id,name")] carproperty carproperty)
        {
            if (ModelState.IsValid)
            {
                db.carproperties.Add(carproperty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carproperty);
        }

        // GET: carproperties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carproperty carproperty = db.carproperties.Find(id);
            if (carproperty == null)
            {
                return HttpNotFound();
            }
            return View(carproperty);
        }

        // POST: carproperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "carproperty_id,name")] carproperty carproperty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carproperty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carproperty);
        }

        // GET: carproperties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carproperty carproperty = db.carproperties.Find(id);
            if (carproperty == null)
            {
                return HttpNotFound();
            }
            return View(carproperty);
        }

        // POST: carproperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carproperty carproperty = db.carproperties.Find(id);
            db.carproperties.Remove(carproperty);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
