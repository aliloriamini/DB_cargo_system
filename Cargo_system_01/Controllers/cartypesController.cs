using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cargo_system_01.Models;
using System.IO;

namespace Cargo_system_01.Controllers
{
    public class cartypesController : Controller
    {
        private Cargo_system01Entities3 db = new Cargo_system01Entities3();

        // GET: cartypes
        public ActionResult Index()
        {
            return View(db.cartypes.ToList());
        }

        // GET: cartypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cartype cartype = db.cartypes.Find(id);
            if (cartype == null)
            {
                return HttpNotFound();
            }
            return View(cartype);
        }

        // GET: cartypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cartypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(cartype cartypes)
        {
            if (cartypes.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(cartypes.ImageFile.FileName);
                string extension = Path.GetExtension(cartypes.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                cartypes.image = "~/Image/car/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/car/"), fileName);
                cartypes.ImageFile.SaveAs(fileName);
            }
            if (ModelState.IsValid)
            {
                db.cartypes.Add(cartypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cartypes);
        }

        // GET: cartypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cartype cartype = db.cartypes.Find(id);
            if (cartype == null)
            {
                return HttpNotFound();
            }
            return View(cartype);
        }

        // POST: cartypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cartype_id,name,image,ImageFile")] cartype cartypes)
        {
            if (cartypes.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(cartypes.ImageFile.FileName);
                string extension = Path.GetExtension(cartypes.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                cartypes.image = "~/Image/car/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/car/"), fileName);
                cartypes.ImageFile.SaveAs(fileName);
            }
            if (ModelState.IsValid)
            {
                db.Entry(cartypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cartypes);
        }

        // GET: cartypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cartype cartype = db.cartypes.Find(id);
            if (cartype == null)
            {
                return HttpNotFound();
            }
            return View(cartype);
        }

        // POST: cartypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cartype cartype = db.cartypes.Find(id);
            db.cartypes.Remove(cartype);
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
