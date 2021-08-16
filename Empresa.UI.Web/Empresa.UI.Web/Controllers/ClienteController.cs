using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Empresa.DB;
using Empresa.Models;

namespace Empresa.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        // GET: ClienteController
        public ActionResult Index()
        {
            var db = new ClienteDB();
            var lista = db.Pesquisar();
            return View(lista);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            var db = new ClienteDB();
            var cliente = db.ObterPorID(id);
            
            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                var db = new ClienteDB();
                db.Incluir(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cliente);
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            var db = new ClienteDB();
            var cliente = db.ObterPorID(id);

            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cliente cliente)
        {
            try
            {
                var db = new ClienteDB();
                db.Alterar(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cliente);
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            var db = new ClienteDB();
            var cliente = db.ObterPorID(id);

            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cliente cliente)
        {
            try
            {
                var db = new ClienteDB();
                db.Excluir(cliente.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
