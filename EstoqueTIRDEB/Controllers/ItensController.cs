using EstoqueTIRDEB.Models;
using EstoqueTIRDEB.Models.ViewModels;
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
        public IActionResult Adicionar(int itemId, int quantidade)
        {
            // Lógica para recuperar informações do item com base no ID do item
            var item = _itensService.FindById(itemId);

            if (item != null)
            {
                var model = new AdicionarItemViewModel
                {
                    ItemId = item.Id,
                    Nome = item.Nome,
                    Modelo = item.Modelo,
                    Especificacoes = item.Especificações,
                    DataAquisicao = item.DataAquisicao
                };

                return View(model);
            }

            // Lógica de tratamento caso o item não seja encontrado
            return RedirectToAction("Index", "Home");
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
