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
    public class LocacaoController : Controller
    {
        private Repository db = new Repository();

        //
        // GET: /Locacao/

        public ActionResult Index()
        {
            var locacoes = db.Locacoes.Include(l => l.Cliente);
            return View(locacoes.ToList());
        }

        //
        // GET: /Locacao/Details/5

        public ActionResult Details(long id = 0)
        {
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        //
        // GET: /Locacao/Create

        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            ViewBag.CopiaId = new SelectList(db.Copias, "Id", "Copia");
            return View();
        }

        //
        // POST: /Locacao/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                db.Locacoes.Add(locacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", locacao.ClienteId);
            ViewBag.CopiaId = new SelectList(db.Copias, "Id", "Copia", locacao.CopiaId);
            return View(locacao);
        }

        //
        // GET: /Locacao/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", locacao.ClienteId);
            ViewBag.CopiaId = new SelectList(db.Copias, "Id", "Copia", locacao.CopiaId);
            return View(locacao);
        }

        //
        // POST: /Locacao/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", locacao.ClienteId);
            ViewBag.CopiaId = new SelectList(db.Copias, "Id", "Copia", locacao.CopiaId);
            return View(locacao);
        }

        public ActionResult Devolver(long id = 0)
        {
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        [HttpPost]
        public ActionResult Devolver(Int64 id, DateTime dataDevolucao)
        {
            Locacao locacao = db.Locacoes.Find(id);
            locacao.DataDevolucao = dataDevolucao;
            if (ModelState.IsValid)
            {
                db.Entry(locacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locacao);
        }

        //
        // GET: /Locacao/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        //
        // POST: /Locacao/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Locacao locacao = db.Locacoes.Find(id);
            db.Locacoes.Remove(locacao);
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