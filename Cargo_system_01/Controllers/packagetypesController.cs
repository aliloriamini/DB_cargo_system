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
    public class packagetypesController : Controller
    {
        private Cargo_system01Entities3 db = new Cargo_system01Entities3();

        // GET: packagetypes
        public ActionResult Index()
        {
            return View(db.packagetypes.ToList());
        }

        // GET: packagetypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            packagetype packagetype = db.packagetypes.Find(id);
            if (packagetype == null)
            {
                return HttpNotFound();
            }
            return View(packagetype);
        }

        // GET: packagetypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: packagetypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "packagetype_id,name")] packagetype packagetype)
        {
            if (ModelState.IsValid)
            {
                db.packagetypes.Add(packagetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(packagetype);
        }

        // GET: packagetypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            packagetype packagetype = db.packagetypes.Find(id);
            if (packagetype == null)
            {
                return HttpNotFound();
            }
            return View(packagetype);
        }

        // POST: packagetypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "packagetype_id,name")] packagetype packagetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(packagetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(packagetype);
        }

        // GET: packagetypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            packagetype packagetype = db.packagetypes.Find(id);
            if (packagetype == null)
            {
                return HttpNotFound();
            }
            return View(packagetype);
        }

        // POST: packagetypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            packagetype packagetype = db.packagetypes.Find(id);
            db.packagetypes.Remove(packagetype);
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
