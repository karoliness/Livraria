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
    public class ClientesController : Controller
    {
        ClienteDAL clienteDAL;

        public ClientesController()
        {
            clienteDAL = new ClienteDAL();
        }

        // GET: Clientes
        public ActionResult Index()
        {
            var model = clienteDAL.ObterTodos().OrderBy(cliente => cliente.Nome);
            return View(model);
        }
        // por quê dá erro quando eu não coloco esse actionResult?
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
             clienteDAL.Adicionar(cliente);
             return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (0 == id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cliente cliente = clienteDAL.ObterPor(id);

            if (null == cliente)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteDAL.Editar(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Delete(int? id)
        {
            if (id == 0 && id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = clienteDAL.ObterPor((int)id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var cliente = clienteDAL.ObterPor(id);
            clienteDAL.Excluir(cliente);
            return RedirectToAction("Index");
        }
    }
}