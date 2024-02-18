using EstoqueTIRDEB.Models;
using EstoqueTIRDEB.Models.ViewModels;
using EstoqueTIRDEB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Controllers
{
    public class ItensController : Controller
    {

        private readonly ItensService _itensService;
        private readonly EstoqueService _estoqueservice;
        private readonly CategoriaService _categoriaService;

        public ItensController(ItensService itensService, EstoqueService estoqueService, CategoriaService categoriaService)
        {
            _itensService = itensService;
            _estoqueservice = estoqueService;
            _categoriaService = categoriaService;
        }

        // GET: ItensController
        public ActionResult Index()
        {
            var list = _itensService.FindAll();

            return View(list);
        }

        // GET: ItensController/Details/5
        public IActionResult DetalhesQuantidade(int itemId)
        {
            var viewModel = _estoqueservice.GetDetalhesQuantidadeViewModel(itemId);

            if (viewModel == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
        }

        public IActionResult ListarItensPorCategoria(int categoriaId)
        {
            var itens = _itensService.ListarPorCategoria(categoriaId);
            return View(itens);
        }

        [HttpGet]
        public IActionResult AdicionarItemAoEstoque()
        {
            // Aqui você pode retornar a view de cadastro de item
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarItemAoEstoque(Itens item, int categoriaId)
        {
            _estoqueservice.AdicionarItemAoEstoque(item, categoriaId);
            return RedirectToAction("Index", "Home"); // Ou outra ação desejada
        }

        [HttpPost]
        public IActionResult AdicionarRemover(int itemId)
        {
            // Lógica para adicionar e remover o item
            return RedirectToAction("ListarItensPorCategoria", new { categoriaId = itemId });
        }

        public IActionResult Create()
        {
            var categorias = _categoriaService.GetAll();
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Itens itens)
        {
            if (ModelState.IsValid)
            {
                _itensService.Insert(itens);
                return RedirectToAction(nameof(Index));
            }
            var categorias = _categoriaService.GetAll();
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nome", itens.CategoriaId);
            return View(itens);
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
