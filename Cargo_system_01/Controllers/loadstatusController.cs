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
    public class loadstatusController : Controller
    {
        private Cargo_system01Entities3 db = new Cargo_system01Entities3();

        // GET: loadstatus
        public ActionResult Index()
        {
            return View(db.loadstatus.ToList());
        }

        // GET: loadstatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loadstatu loadstatu = db.loadstatus.Find(id);
            if (loadstatu == null)
            {
                return HttpNotFound();
            }
            return View(loadstatu);
        }

        // GET: loadstatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: loadstatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "loadstatus_id,name")] loadstatu loadstatu)
        {
            if (ModelState.IsValid)
            {
                db.loadstatus.Add(loadstatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loadstatu);
        }

        // GET: loadstatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loadstatu loadstatu = db.loadstatus.Find(id);
            if (loadstatu == null)
            {
                return HttpNotFound();
            }
            return View(loadstatu);
        }

        // POST: loadstatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "loadstatus_id,name")] loadstatu loadstatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loadstatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loadstatu);
        }

        // GET: loadstatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loadstatu loadstatu = db.loadstatus.Find(id);
            if (loadstatu == null)
            {
                return HttpNotFound();
            }
            return View(loadstatu);
        }

        // POST: loadstatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            loadstatu loadstatu = db.loadstatus.Find(id);
            db.loadstatus.Remove(loadstatu);
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
