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
    public class ItensController : Controller
    {

        private readonly ItensService _itensService;

        public ItensController(ItensService itensService)
        {
            _itensService = itensService;
        }

        // GET: ItensController
        public ActionResult Index()
        {
            var list = _itensService.FindAll();

            return View(list);
        }

        // GET: ItensController/Details/5
        public ActionResult Adicionar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _itensService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        // GET: ItensController/Create
        public ActionResult Create()
        {
            return View();
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
            return View(id);
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _itensService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST: ItensController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _itensService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
