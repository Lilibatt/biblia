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
    public class publishinggsController : Controller
    {
        private bibliaEntities db = new bibliaEntities();

        // GET: publishinggs
        public ActionResult Index()
        {
            return View(db.publishingg.ToList());
        }

        // GET: publishinggs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publishingg publishingg = db.publishingg.Find(id);
            if (publishingg == null)
            {
                return HttpNotFound();
            }
            return View(publishingg);
        }

        // GET: publishinggs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: publishinggs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,city")] publishingg publishingg)
        {
            if (ModelState.IsValid)
            {
                db.publishingg.Add(publishingg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publishingg);
        }

        // GET: publishinggs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publishingg publishingg = db.publishingg.Find(id);
            if (publishingg == null)
            {
                return HttpNotFound();
            }
            return View(publishingg);
        }

        // POST: publishinggs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,city")] publishingg publishingg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publishingg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publishingg);
        }

        // GET: publishinggs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publishingg publishingg = db.publishingg.Find(id);
            if (publishingg == null)
            {
                return HttpNotFound();
            }
            return View(publishingg);
        }

        // POST: publishinggs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            publishingg publishingg = db.publishingg.Find(id);
            db.publishingg.Remove(publishingg);
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
