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
    public class LivresController : Controller
    {
        private Loango_dbEntities1 db = new Loango_dbEntities1();

        // GET: Livres
        public ActionResult Index()
        {
            var livres = db.Livres.Include(l => l.Auteur).Include(l => l.Categorie).Include(l => l.Edition).Include(l => l.Rayon).Include(l => l.User);
            return View(livres.ToList());
        }

        // GET: Livres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livres livres = db.Livres.Find(id);
            if (livres == null)
            {
                return HttpNotFound();
            }
            return View(livres);
        }

        // GET: Livres/Create
        public ActionResult Create()
        {
            ViewBag.id_auteur_liv = new SelectList(db.Auteur, "id_auteur", "nom_auteur");
            ViewBag.id_cat_liv = new SelectList(db.Categorie, "id_cat", "code_cat");
            ViewBag.id_edition_liv = new SelectList(db.Edition, "id_edition", "nom_edition");
            ViewBag.id_rayon_liv = new SelectList(db.Rayon, "id_rayon", "code_rayon");
            ViewBag.id_user_liv = new SelectList(db.User, "id_user", "nom_user");
            return View();
        }

        // POST: Livres/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_livre,titre_livre,date_acqui_livre,anné_pub_livre,nbre_page_livre,id_auteur_liv,id_cat_liv,id_rayon_liv,id_edition_liv,id_user_liv")] Livres livres)
        {
            if (ModelState.IsValid)
            {
                db.Livres.Add(livres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_auteur_liv = new SelectList(db.Auteur, "id_auteur", "nom_auteur", livres.id_auteur_liv);
            ViewBag.id_cat_liv = new SelectList(db.Categorie, "id_cat", "code_cat", livres.id_cat_liv);
            ViewBag.id_edition_liv = new SelectList(db.Edition, "id_edition", "nom_edition", livres.id_edition_liv);
            ViewBag.id_rayon_liv = new SelectList(db.Rayon, "id_rayon", "code_rayon", livres.id_rayon_liv);
            ViewBag.id_user_liv = new SelectList(db.User, "id_user", "nom_user", livres.id_user_liv);
            return View(livres);
        }

        // GET: Livres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livres livres = db.Livres.Find(id);
            if (livres == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_auteur_liv = new SelectList(db.Auteur, "id_auteur", "nom_auteur", livres.id_auteur_liv);
            ViewBag.id_cat_liv = new SelectList(db.Categorie, "id_cat", "code_cat", livres.id_cat_liv);
            ViewBag.id_edition_liv = new SelectList(db.Edition, "id_edition", "nom_edition", livres.id_edition_liv);
            ViewBag.id_rayon_liv = new SelectList(db.Rayon, "id_rayon", "code_rayon", livres.id_rayon_liv);
            ViewBag.id_user_liv = new SelectList(db.User, "id_user", "nom_user", livres.id_user_liv);
            return View(livres);
        }

        // POST: Livres/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_livre,titre_livre,date_acqui_livre,anné_pub_livre,nbre_page_livre,id_auteur_liv,id_cat_liv,id_rayon_liv,id_edition_liv,id_user_liv")] Livres livres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_auteur_liv = new SelectList(db.Auteur, "id_auteur", "nom_auteur", livres.id_auteur_liv);
            ViewBag.id_cat_liv = new SelectList(db.Categorie, "id_cat", "code_cat", livres.id_cat_liv);
            ViewBag.id_edition_liv = new SelectList(db.Edition, "id_edition", "nom_edition", livres.id_edition_liv);
            ViewBag.id_rayon_liv = new SelectList(db.Rayon, "id_rayon", "code_rayon", livres.id_rayon_liv);
            ViewBag.id_user_liv = new SelectList(db.User, "id_user", "nom_user", livres.id_user_liv);
            return View(livres);
        }

        // GET: Livres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livres livres = db.Livres.Find(id);
            if (livres == null)
            {
                return HttpNotFound();
            }
            return View(livres);
        }

        // POST: Livres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livres livres = db.Livres.Find(id);
            db.Livres.Remove(livres);
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
