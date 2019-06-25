using Livraria.DAL;
using Livraria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Livraria.Controllers
{
    public class CategoriasController : Controller
    {
        CategoriaDAL categoriaDAL;

        public CategoriasController()
        {
            categoriaDAL = new CategoriaDAL();
        }

        // GET: Categorias
        public ActionResult Index()
        {
            var model = categoriaDAL.ObterTodos().OrderBy(cliente => cliente.Nome);
            return View(model);
        }
        // por quê dá erro quando eu não coloco esse actionResult?
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categoriaDAL.Adicionar(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (0 == id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = categoriaDAL.ObterPor(id);

            if (null == categoria)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoriaDAL.Editar(categoria);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public ActionResult Delete(int? id)
        {
            if (id == 0 && id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoria = categoriaDAL.ObterPor((int)id);

            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var categoria = categoriaDAL.ObterPor(id);
            categoriaDAL.Excluir(categoria);
            return RedirectToAction("Index");
        }
    }
}