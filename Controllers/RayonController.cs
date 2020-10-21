using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Loango_app.Models;

namespace Loango_app.Controllers
{
    public class RayonController : Controller
    {
        private Loango_dbEntities1 db = new Loango_dbEntities1();

        // GET: Rayon
        public ActionResult Index()
        {
            return View(db.Rayon.ToList());
        }

        // GET: Rayon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rayon rayon = db.Rayon.Find(id);
            if (rayon == null)
            {
                return HttpNotFound();
            }
            return View(rayon);
        }

        // GET: Rayon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rayon/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_rayon,code_rayon")] Rayon rayon)
        {
            if (ModelState.IsValid)
            {
                db.Rayon.Add(rayon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rayon);
        }

        // GET: Rayon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rayon rayon = db.Rayon.Find(id);
            if (rayon == null)
            {
                return HttpNotFound();
            }
            return View(rayon);
        }

        // POST: Rayon/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_rayon,code_rayon")] Rayon rayon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rayon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rayon);
        }

        // GET: Rayon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rayon rayon = db.Rayon.Find(id);
            if (rayon == null)
            {
                return HttpNotFound();
            }
            return View(rayon);
        }

        // POST: Rayon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rayon rayon = db.Rayon.Find(id);
            db.Rayon.Remove(rayon);
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
