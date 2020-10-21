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
    public class EditionController : Controller
    {
        private Loango_dbEntities1 db = new Loango_dbEntities1();

        // GET: Edition
        public ActionResult Index()
        {
            return View(db.Edition.ToList());
        }

        // GET: Edition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edition edition = db.Edition.Find(id);
            if (edition == null)
            {
                return HttpNotFound();
            }
            return View(edition);
        }

        // GET: Edition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Edition/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_edition,nom_edition,pays_edition")] Edition edition)
        {
            if (ModelState.IsValid)
            {
                db.Edition.Add(edition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(edition);
        }

        // GET: Edition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edition edition = db.Edition.Find(id);
            if (edition == null)
            {
                return HttpNotFound();
            }
            return View(edition);
        }

        // POST: Edition/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_edition,nom_edition,pays_edition")] Edition edition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(edition);
        }

        // GET: Edition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edition edition = db.Edition.Find(id);
            if (edition == null)
            {
                return HttpNotFound();
            }
            return View(edition);
        }

        // POST: Edition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Edition edition = db.Edition.Find(id);
            db.Edition.Remove(edition);
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
