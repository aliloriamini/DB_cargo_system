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
    public class ordersController : Controller
    {
        private Cargo_system01Entities3 db = new Cargo_system01Entities3();

        // GET: orders
        public ActionResult Index()
        {
            var orders = db.orders.Include(o => o.cartype).Include(o => o.city).Include(o => o.city1).Include(o => o.customer).Include(o => o.driver).Include(o => o.loadstatu).Include(o => o.loadtype).Include(o => o.packagetype);
            return View(orders.ToList());
        }

        // GET: orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: orders/Create
        public ActionResult Create()
        {
            ViewBag.cartype_id = new SelectList(db.cartypes, "cartype_id", "name");
            ViewBag.from_city = new SelectList(db.cities, "city_id", "name");
            ViewBag.to_city = new SelectList(db.cities, "city_id", "name");
            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "name");
            ViewBag.driver_id = new SelectList(db.drivers, "driver_id", "name");
            ViewBag.order_status = new SelectList(db.loadstatus, "loadstatus_id", "name");
            ViewBag.load_type = new SelectList(db.loadtypes, "loadtype_id", "name");
            ViewBag.package_type = new SelectList(db.packagetypes, "packagetype_id", "name");
            return View();
        }

        // POST: orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orders_id,customer_id,from_adr,from_name,from_mobile,from_date,from_city,to_name,to_mobile,to_date,to_city,load_type,package_type,load_weight,cartype_id,driver_id,driver_date,order_status,description")] order order)
        {
            if (ModelState.IsValid)
            {
                db.orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cartype_id = new SelectList(db.cartypes, "cartype_id", "name", order.cartype_id);
            ViewBag.from_city = new SelectList(db.cities, "city_id", "name", order.from_city);
            ViewBag.to_city = new SelectList(db.cities, "city_id", "name", order.to_city);
            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "name", order.customer_id);
            ViewBag.driver_id = new SelectList(db.drivers, "driver_id", "name", order.driver_id);
            ViewBag.order_status = new SelectList(db.loadstatus, "loadstatus_id", "name", order.order_status);
            ViewBag.load_type = new SelectList(db.loadtypes, "loadtype_id", "name", order.load_type);
            ViewBag.package_type = new SelectList(db.packagetypes, "packagetype_id", "name", order.package_type);
            return View(order);
        }

        // GET: orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.cartype_id = new SelectList(db.cartypes, "cartype_id", "name", order.cartype_id);
            ViewBag.from_city = new SelectList(db.cities, "city_id", "name", order.from_city);
            ViewBag.to_city = new SelectList(db.cities, "city_id", "name", order.to_city);
            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "name", order.customer_id);
            ViewBag.driver_id = new SelectList(db.drivers, "driver_id", "name", order.driver_id);
            ViewBag.order_status = new SelectList(db.loadstatus, "loadstatus_id", "name", order.order_status);
            ViewBag.load_type = new SelectList(db.loadtypes, "loadtype_id", "name", order.load_type);
            ViewBag.package_type = new SelectList(db.packagetypes, "packagetype_id", "name", order.package_type);
            return View(order);
        }

        // POST: orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orders_id,customer_id,from_adr,from_name,from_mobile,from_date,from_city,to_name,to_mobile,to_date,to_city,load_type,package_type,load_weight,cartype_id,driver_id,driver_date,order_status,description")] order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cartype_id = new SelectList(db.cartypes, "cartype_id", "name", order.cartype_id);
            ViewBag.from_city = new SelectList(db.cities, "city_id", "name", order.from_city);
            ViewBag.to_city = new SelectList(db.cities, "city_id", "name", order.to_city);
            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "name", order.customer_id);
            ViewBag.driver_id = new SelectList(db.drivers, "driver_id", "name", order.driver_id);
            ViewBag.order_status = new SelectList(db.loadstatus, "loadstatus_id", "name", order.order_status);
            ViewBag.load_type = new SelectList(db.loadtypes, "loadtype_id", "name", order.load_type);
            ViewBag.package_type = new SelectList(db.packagetypes, "packagetype_id", "name", order.package_type);
            return View(order);
        }

        // GET: orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order order = db.orders.Find(id);
            db.orders.Remove(order);
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
