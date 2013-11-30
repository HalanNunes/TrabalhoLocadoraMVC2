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
    [Authorize]
    public class TipoTituloController : Controller
    {
        private Repository db = new Repository();

        //
        // GET: /TipoTitulo/

        public ActionResult Index()
        {
            return View(db.TipoTitulos.ToList());
        }

        //
        // GET: /TipoTitulo/Details/5

        public ActionResult Details(long id = 0)
        {
            TipoTitulo tipotitulo = db.TipoTitulos.Find(id);
            if (tipotitulo == null)
            {
                return HttpNotFound();
            }
            return View(tipotitulo);
        }

        //
        // GET: /TipoTitulo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoTitulo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoTitulo tipotitulo)
        {
            if (ModelState.IsValid)
            {
                db.TipoTitulos.Add(tipotitulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipotitulo);
        }

        //
        // GET: /TipoTitulo/Edit/5

        public ActionResult Edit(long id = 0)
        {
            TipoTitulo tipotitulo = db.TipoTitulos.Find(id);
            if (tipotitulo == null)
            {
                return HttpNotFound();
            }
            return View(tipotitulo);
        }

        //
        // POST: /TipoTitulo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoTitulo tipotitulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipotitulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipotitulo);
        }

        //
        // GET: /TipoTitulo/Delete/5

        public ActionResult Delete(long id = 0)
        {
            TipoTitulo tipotitulo = db.TipoTitulos.Find(id);
            if (tipotitulo == null)
            {
                return HttpNotFound();
            }
            return View(tipotitulo);
        }

        //
        // POST: /TipoTitulo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TipoTitulo tipotitulo = db.TipoTitulos.Find(id);
            db.TipoTitulos.Remove(tipotitulo);
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