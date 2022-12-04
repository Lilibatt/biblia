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
    public class publication_typeController : Controller
    {
        private bibliaEntities db = new bibliaEntities();

        // GET: publication_type
        public ActionResult Index()
        {
            return View(db.publication_type.ToList());
        }

        // GET: publication_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publication_type publication_type = db.publication_type.Find(id);
            if (publication_type == null)
            {
                return HttpNotFound();
            }
            return View(publication_type);
        }

        // GET: publication_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: publication_type/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,publication_type1")] publication_type publication_type)
        {
            if (ModelState.IsValid)
            {
                db.publication_type.Add(publication_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publication_type);
        }

        // GET: publication_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publication_type publication_type = db.publication_type.Find(id);
            if (publication_type == null)
            {
                return HttpNotFound();
            }
            return View(publication_type);
        }

        // POST: publication_type/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,publication_type1")] publication_type publication_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publication_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publication_type);
        }

        // GET: publication_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            publication_type publication_type = db.publication_type.Find(id);
            if (publication_type == null)
            {
                return HttpNotFound();
            }
            return View(publication_type);
        }

        // POST: publication_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            publication_type publication_type = db.publication_type.Find(id);
            db.publication_type.Remove(publication_type);
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
