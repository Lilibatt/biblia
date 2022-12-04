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
    public class issuance_of_booksController : Controller
    {
        private bibliaEntities db = new bibliaEntities();

        // GET: issuance_of_books
        public ActionResult Index()
        {
            var issuance_of_books = db.issuance_of_books.Include(i => i.books).Include(i => i.librarian).Include(i => i.reader);
            return View(issuance_of_books.ToList());
        }

        // GET: issuance_of_books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            issuance_of_books issuance_of_books = db.issuance_of_books.Find(id);
            if (issuance_of_books == null)
            {
                return HttpNotFound();
            }
            return View(issuance_of_books);
        }

        // GET: issuance_of_books/Create
        public ActionResult Create()
        {
            ViewBag.id_book = new SelectList(db.books, "id", "name");
            ViewBag.id_library = new SelectList(db.librarian, "id", "FIO");
            ViewBag.id_reader = new SelectList(db.reader, "id", "FIO");
            return View();
        }

        // POST: issuance_of_books/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_library,id_reader,date_of_issue,return_date,id_book")] issuance_of_books issuance_of_books)
        {
            if (ModelState.IsValid)
            {
                db.issuance_of_books.Add(issuance_of_books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_book = new SelectList(db.books, "id", "name", issuance_of_books.id_book);
            ViewBag.id_library = new SelectList(db.librarian, "id", "FIO", issuance_of_books.id_library);
            ViewBag.id_reader = new SelectList(db.reader, "id", "FIO", issuance_of_books.id_reader);
            return View(issuance_of_books);
        }

        // GET: issuance_of_books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            issuance_of_books issuance_of_books = db.issuance_of_books.Find(id);
            if (issuance_of_books == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_book = new SelectList(db.books, "id", "name", issuance_of_books.id_book);
            ViewBag.id_library = new SelectList(db.librarian, "id", "FIO", issuance_of_books.id_library);
            ViewBag.id_reader = new SelectList(db.reader, "id", "FIO", issuance_of_books.id_reader);
            return View(issuance_of_books);
        }

        // POST: issuance_of_books/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_library,id_reader,date_of_issue,return_date,id_book")] issuance_of_books issuance_of_books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issuance_of_books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_book = new SelectList(db.books, "id", "name", issuance_of_books.id_book);
            ViewBag.id_library = new SelectList(db.librarian, "id", "FIO", issuance_of_books.id_library);
            ViewBag.id_reader = new SelectList(db.reader, "id", "FIO", issuance_of_books.id_reader);
            return View(issuance_of_books);
        }

        // GET: issuance_of_books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            issuance_of_books issuance_of_books = db.issuance_of_books.Find(id);
            if (issuance_of_books == null)
            {
                return HttpNotFound();
            }
            return View(issuance_of_books);
        }

        // POST: issuance_of_books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            issuance_of_books issuance_of_books = db.issuance_of_books.Find(id);
            db.issuance_of_books.Remove(issuance_of_books);
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
