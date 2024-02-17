using EstoqueTIRDEB.Models;
using EstoqueTIRDEB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ItensService _itensService;
        private readonly CategoriaService _categoriaService;

        public CategoriaController(ItensService itensService, CategoriaService categoriaService)
        {
            _itensService = itensService;
            _categoriaService = categoriaService;
        }



        // GET: ItensController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ItensController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: ItensController/Create
        public ActionResult Create()
        {
            var categoria = _categoriaService.FindAll();
            var viewModel = new ItensFormViewModel { Categoria = categoria };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Itens itens)
        {
            _itensService.Insert(itens);
            return RedirectToAction(nameof(Index));
        }

        // GET: ItensController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItensController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItensController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItensController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
