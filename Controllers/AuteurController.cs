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
    public class AuteurController : Controller
    {
        private Loango_dbEntities1 db = new Loango_dbEntities1();

        // GET: Auteur
        public ActionResult Index()
        {
            return View(db.Auteur.ToList());
        }

        // GET: Auteur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteur auteur = db.Auteur.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // GET: Auteur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auteur/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_auteur,nom_auteur,nationnalité_auteur,sexe_auteur")] Auteur auteur)
        {
            if (ModelState.IsValid)
            {
                db.Auteur.Add(auteur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auteur);
        }

        // GET: Auteur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteur auteur = db.Auteur.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // POST: Auteur/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_auteur,nom_auteur,nationnalité_auteur,sexe_auteur")] Auteur auteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auteur);
        }

        // GET: Auteur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteur auteur = db.Auteur.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // POST: Auteur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auteur auteur = db.Auteur.Find(id);
            db.Auteur.Remove(auteur);
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
