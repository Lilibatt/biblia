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
    public class booksController : Controller
    {
        private bibliaEntities db = new bibliaEntities();

        // GET: books
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.TypeSortParm = sortOrder == "publishing_type" ? "publishing_type_desc" : "id_publishing_type";
            var name = from s in db.books
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                name = name.Where(s => s.name.Contains(searchString)); /*|| s.FirstMidName.Contains(searchString));*/
            }


            switch (sortOrder)
            {
                case "name_desc":
                    name = name.OrderByDescending(s => s.name);
                    break;
                case "publishing_type":
                    name = name.OrderBy(s => s.id_publishing_type);
                    break;
                case "publishing_type_desc":
                    name = name.OrderByDescending(s => s.id_publishing_type);
                    break;
                default:
                    name = name.OrderBy(s => s.name);
                    break;
            }
            return View(name.ToList());
        }


        // GET: books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            books books = db.books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // GET: books/Create
        public ActionResult Create()
        {
            ViewBag.id_publishing_type = new SelectList(db.publication_type, "id", "publication_type1");
            ViewBag.id_publishing = new SelectList(db.publishingg, "id", "name");
            ViewBag.id_storage_location = new SelectList(db.storage_location, "id", "storage_location1");
            return View();
        }

        // POST: books/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,author,id_publishing,id_publishing_type,id_storage_location")] books books)
        {
            if (ModelState.IsValid)
            {
                db.books.Add(books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_publishing_type = new SelectList(db.publication_type, "id", "publication_type1", books.id_publishing_type);
            ViewBag.id_publishing = new SelectList(db.publishingg, "id", "name", books.id_publishing);
            ViewBag.id_storage_location = new SelectList(db.storage_location, "id", "storage_location1", books.id_storage_location);
            return View(books);
        }

        // GET: books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            books books = db.books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_publishing_type = new SelectList(db.publication_type, "id", "publication_type1", books.id_publishing_type);
            ViewBag.id_publishing = new SelectList(db.publishingg, "id", "name", books.id_publishing);
            ViewBag.id_storage_location = new SelectList(db.storage_location, "id", "storage_location1", books.id_storage_location);
            return View(books);
        }

        // POST: books/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,author,id_publishing,id_publishing_type,id_storage_location")] books books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_publishing_type = new SelectList(db.publication_type, "id", "publication_type1", books.id_publishing_type);
            ViewBag.id_publishing = new SelectList(db.publishingg, "id", "name", books.id_publishing);
            ViewBag.id_storage_location = new SelectList(db.storage_location, "id", "storage_location1", books.id_storage_location);
            return View(books);
        }

        // GET: books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            books books = db.books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            books books = db.books.Find(id);
            db.books.Remove(books);
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
