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
    public class TituloController : Controller
    {
        private Repository db = new Repository();

        //
        // GET: /Titulo/

        public ActionResult Index()
        {
            var titulos = db.Titulos.Include(i => i.Atores).Include(i => i.Generos).ToList();
            return View(db.Titulos.ToList());
        }

        //
        // GET: /Titulo/Details/5

        public ActionResult Details(int id = 0)
        {
            Titulo titulo = db.Titulos.Find(id);
            if (titulo == null)
            {
                return HttpNotFound();
            }
            return View(titulo);
        }

        //
        // GET: /Titulo/Create

        public ActionResult Create()
        {
            ViewBag.MultiSelectAtores = new MultiSelectList(db.Atores.ToList(), "Id", "Nome");
            ViewBag.MultiSelectGeneros = new MultiSelectList(db.Generos.ToList(), "Id", "Descricao");
            return View();
        }

        //
        // POST: /Titulo/Create

        [HttpPost]
        public ActionResult Create(Titulo titulo, FormCollection formCollection, string[] arrayAtores, string[] arrayGeneros)
        {
            titulo.TipoTitulo = db.TipoTitulos.Find(titulo.TipoTituloId);
            if (arrayAtores != null)
            {
                titulo.Atores = new List<Ator>();
                foreach (var ator in arrayAtores)
                {
                    var atorToAdd = db.Atores.Find(int.Parse(ator));
                    titulo.Atores.Add(atorToAdd);
                }
            }

            if (arrayGeneros != null)
            {
                titulo.Generos = new List<Genero>();
                foreach (var genero in arrayGeneros)
                {
                    var generoToAdd = db.Generos.Find(int.Parse(genero));
                    titulo.Generos.Add(generoToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                db.Titulos.Add(titulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MultiSelectAtores = new MultiSelectList(db.Atores.ToList(), "Id", "Nome");
            ViewBag.MultiSelectGeneros = new MultiSelectList(db.Generos.ToList(), "Id", "Descricao");
            return View(titulo);
        }

        //
        // GET: /Titulo/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Titulo titulo = db.Titulos.Find(id);
            if (titulo == null)
            {
                return HttpNotFound();
            }
            var selectedAtores = titulo.Atores.Select(s => s.Id.ToString());
            var selectedGeneros = titulo.Generos.Select(s => s.Id.ToString());

            ViewBag.MultiSelectAtores = new MultiSelectList(db.Atores.ToList(), "Id", "Nome", selectedAtores);
            ViewBag.MultiSelectGeneros = new MultiSelectList(db.Generos.ToList(), "Id", "Descricao", selectedGeneros);
            return View(titulo);
        }

        //
        // POST: /Titulo/Edit/5

        [HttpPost]
        public ActionResult Edit(int? id, FormCollection formCollection, string[] arrayAtores, string[] arrayGeneros)
        {
            var tituloToUpdate = db.Titulos
                .Include(i => i.Atores)
                .Include(i => i.Generos)
                .Where(i => i.Id == id)
                .Single();

            if (arrayAtores == null)
            {
                tituloToUpdate.Atores = new List<Ator>();
                foreach (var ator in db.Atores)
                {
                    tituloToUpdate.Atores.Remove(ator);
                }
            }
            else
            {
                var selectedAtoresHS = new HashSet<string>(arrayAtores);
                var tituloAtores = new HashSet<Int32>(tituloToUpdate.Atores.Select(s => s.Id));
                foreach (var ator in db.Atores)
                {
                    if (selectedAtoresHS.Contains(ator.Id.ToString()))
                    {
                        if (!tituloAtores.Contains(ator.Id))
                        {
                            tituloToUpdate.Atores.Add(ator);
                        }
                    }
                    else
                    {
                        if (tituloAtores.Contains(ator.Id))
                        {
                            tituloToUpdate.Atores.Remove(ator);
                        }
                    }
                }
            }

            if (arrayGeneros == null)
            {
                tituloToUpdate.Generos = new List<Genero>();
                foreach (var genero in db.Generos)
                {
                    tituloToUpdate.Generos.Remove(genero);
                }
            }
            else
            {
                var selectedGenerosHS = new HashSet<string>(arrayGeneros);
                var tituloGeneros = new HashSet<Int64>(tituloToUpdate.Generos.Select(s => s.Id));
                foreach (var genero in db.Generos)
                {
                    if (selectedGenerosHS.Contains(genero.Id.ToString()))
                    {
                        if (!tituloGeneros.Contains(genero.Id))
                        {
                            tituloToUpdate.Generos.Add(genero);
                        }
                    }
                    else
                    {
                        if (tituloGeneros.Contains(genero.Id))
                        {
                            tituloToUpdate.Generos.Remove(genero);
                        }
                    }
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(tituloToUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MultiSelectAtores = new MultiSelectList(db.Atores.ToList(), "Id", "Nome");
            ViewBag.MultiSelectGeneros = new MultiSelectList(db.Generos.ToList(), "Id", "Descricao");
            return View(tituloToUpdate);
        }

        //
        // GET: /Titulo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Titulo titulo = db.Titulos.Find(id);
            if (titulo == null)
            {
                return HttpNotFound();
            }
            return View(titulo);
        }

        //
        // POST: /Titulo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Titulo titulo = db.Titulos.Find(id);
            db.Titulos.Remove(titulo);
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