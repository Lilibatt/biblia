using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using biblia_курсач.Models;

namespace biblia_курсач.Controllers
{
    public class storage_locationController : Controller
    {
        private bibliaEntities db = new bibliaEntities();

        // GET: storage_location
        public ActionResult Index()
        {
            return View(db.storage_location.ToList());
        }

        // GET: storage_location/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            storage_location storage_location = db.storage_location.Find(id);
            if (storage_location == null)
            {
                return HttpNotFound();
            }
            return View(storage_location);
        }

        // GET: storage_location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: storage_location/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,storage_location1")] storage_location storage_location)
        {
            if (ModelState.IsValid)
            {
                db.storage_location.Add(storage_location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storage_location);
        }

        // GET: storage_location/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            storage_location storage_location = db.storage_location.Find(id);
            if (storage_location == null)
            {
                return HttpNotFound();
            }
            return View(storage_location);
        }

        // POST: storage_location/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,storage_location1")] storage_location storage_location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storage_location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storage_location);
        }

        // GET: storage_location/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            storage_location storage_location = db.storage_location.Find(id);
            if (storage_location == null)
            {
                return HttpNotFound();
            }
            return View(storage_location);
        }

        // POST: storage_location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            storage_location storage_location = db.storage_location.Find(id);
            db.storage_location.Remove(storage_location);
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
