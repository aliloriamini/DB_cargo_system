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
    public class driversController : Controller
    {
        private Cargo_system01Entities3 db = new Cargo_system01Entities3();

        // GET: drivers
        public ActionResult Index()
        {
            var drivers = db.drivers.Include(d => d.carproperty).Include(d => d.cartype);
            return View(drivers.ToList());
        }

        // GET: drivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            driver driver = db.drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // GET: drivers/Create
        public ActionResult Create()
        {
            ViewBag.carproperty_id = new SelectList(db.carproperties, "carproperty_id", "name");
            ViewBag.cartype_id = new SelectList(db.cartypes, "cartype_id", "name");
            return View();
        }

        // POST: drivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "driver_id,name,family,cartype_id,carproperty_id,tel,mobile,adr,shaba,ImageFile")] driver driver)
        {
            if (driver.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(driver.ImageFile.FileName);
                string extension = Path.GetExtension(driver.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                driver.carimg = "~/Image/driver/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/driver/"), fileName);
                driver.ImageFile.SaveAs(fileName);
            }
            if (ModelState.IsValid)
            {
                db.drivers.Add(driver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.carproperty_id = new SelectList(db.carproperties, "carproperty_id", "name", driver.carproperty_id);
            ViewBag.cartype_id = new SelectList(db.cartypes, "cartype_id", "name", driver.cartype_id);
            return View(driver);
        }

        // GET: drivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            driver driver = db.drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            ViewBag.carproperty_id = new SelectList(db.carproperties, "carproperty_id", "name", driver.carproperty_id);
            ViewBag.cartype_id = new SelectList(db.cartypes, "cartype_id", "name", driver.cartype_id);
            return View(driver);
        }

        // POST: drivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "driver_id,name,family,cartype_id,carproperty_id,tel,mobile,adr,shaba,carimg,ImageFile")] driver driver)
        {
            if (driver.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(driver.ImageFile.FileName);
                string extension = Path.GetExtension(driver.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                driver.carimg = "~/Image/driver/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/driver/"), fileName);
                driver.ImageFile.SaveAs(fileName);
            }
            if (ModelState.IsValid)
            {
                db.Entry(driver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.carproperty_id = new SelectList(db.carproperties, "carproperty_id", "name", driver.carproperty_id);
            ViewBag.cartype_id = new SelectList(db.cartypes, "cartype_id", "name", driver.cartype_id);
            return View(driver);
        }

        // GET: drivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            driver driver = db.drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // POST: drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            driver driver = db.drivers.Find(id);
            db.drivers.Remove(driver);
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
