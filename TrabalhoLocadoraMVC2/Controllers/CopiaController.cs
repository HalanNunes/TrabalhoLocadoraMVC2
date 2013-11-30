using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabalhoLocadoraMVC2.Models;

namespace TrabalhoLocadoraMVC2.Controllers
{
    public class CopiaController : Controller
    {
        private Repository db = new Repository();

        //
        // GET: /Copia/

        public ActionResult Index()
        {
            var copias = db.Copias.Include(c => c.Titulo).Include(c => c.TipoCopia);
            return View(copias.ToList());
        }

        //
        // GET: /Copia/Details/5

        public ActionResult Details(long id = 0)
        {
            Copia copia = db.Copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            return View(copia);
        }

        //
        // GET: /Copia/Create

        public ActionResult Create()
        {
            ViewBag.TituloId = new SelectList(db.Titulos, "Id", "Nome");
            ViewBag.TipoCopiaId = new SelectList(db.TipoCopias, "Id", "Descricao");
            return View();
        }

        //
        // POST: /Copia/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Copia copia)
        {
            if (ModelState.IsValid)
            {
                db.Copias.Add(copia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TituloId = new SelectList(db.Titulos, "Id", "Nome", copia.TituloId);
            ViewBag.TipoCopiaId = new SelectList(db.TipoCopias, "Id", "Descricao", copia.TipoCopiaId);
            return View(copia);
        }

        //
        // GET: /Copia/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Copia copia = db.Copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            ViewBag.TituloId = new SelectList(db.Titulos, "Id", "Nome", copia.TituloId);
            ViewBag.TipoCopiaId = new SelectList(db.TipoCopias, "Id", "Descricao", copia.TipoCopiaId);
            return View(copia);
        }

        //
        // POST: /Copia/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Copia copia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(copia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TituloId = new SelectList(db.Titulos, "Id", "Nome", copia.TituloId);
            ViewBag.TipoCopiaId = new SelectList(db.TipoCopias, "Id", "Descricao", copia.TipoCopiaId);
            return View(copia);
        }

        //
        // GET: /Copia/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Copia copia = db.Copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            return View(copia);
        }

        //
        // POST: /Copia/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Copia copia = db.Copias.Find(id);
            db.Copias.Remove(copia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}