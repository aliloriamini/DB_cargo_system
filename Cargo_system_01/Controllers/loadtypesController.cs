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
    public class loadtypesController : Controller
    {
        private Cargo_system01Entities3 db = new Cargo_system01Entities3();

        // GET: loadtypes
        public ActionResult Index()
        {
            return View(db.loadtypes.ToList());
        }

        // GET: loadtypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loadtype loadtype = db.loadtypes.Find(id);
            if (loadtype == null)
            {
                return HttpNotFound();
            }
            return View(loadtype);
        }

        // GET: loadtypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: loadtypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "loadtype_id,name")] loadtype loadtype)
        {
            if (ModelState.IsValid)
            {
                db.loadtypes.Add(loadtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loadtype);
        }

        // GET: loadtypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loadtype loadtype = db.loadtypes.Find(id);
            if (loadtype == null)
            {
                return HttpNotFound();
            }
            return View(loadtype);
        }

        // POST: loadtypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "loadtype_id,name")] loadtype loadtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loadtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loadtype);
        }

        // GET: loadtypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loadtype loadtype = db.loadtypes.Find(id);
            if (loadtype == null)
            {
                return HttpNotFound();
            }
            return View(loadtype);
        }

        // POST: loadtypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            loadtype loadtype = db.loadtypes.Find(id);
            db.loadtypes.Remove(loadtype);
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
