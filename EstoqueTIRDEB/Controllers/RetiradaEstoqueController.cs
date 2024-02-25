using EstoqueTIRDEB.Models;
using EstoqueTIRDEB.Services;
using EstoqueTIRDEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EstoqueTIRDEB.Controllers
{
    public class RetiradaEstoqueController : Controller
    {
        private readonly RetiradaEstoqueService _retiradaEstoqueService;
        private readonly ItensService _itensService;
        private readonly EstoqueService _estoqueService;

        public RetiradaEstoqueController(RetiradaEstoqueService retiradaEstoqueService, ItensService itensService, EstoqueService estoqueService)
        {
            _retiradaEstoqueService = retiradaEstoqueService;
            _itensService = itensService;
            _estoqueService = estoqueService;
        }

        public IActionResult Index()
        {
            var viewModel = new RetiradaEstoqueViewModel
            {
                RetiradasEstoque = _retiradaEstoqueService.GetAll(),
                Itens = _itensService.FindAll()
            };

            return View(viewModel);
        }

        // GET: RetiradaEstoque/Create
        public IActionResult Create()
        {
            ViewBag.Items = _estoqueService.GetAll(); // Carrega todos os itens do estoque para a view
            return View();
        }

        // POST: RetiradaEstoque/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RetiradaEstoque retiradaEstoque)
        {
            if (ModelState.IsValid)
            {
                retiradaEstoque.DataHoraRetirada = DateTime.Now; // Define a data e hora da retirada como o momento atual
                _retiradaEstoqueService.Create(retiradaEstoque);

                // Atualizar a quantidade disponível do item no estoque
                var item = _itensService.GetById(retiradaEstoque.ItemId);
                item.Quantidade -= retiradaEstoque.QuantidadeRetirada;
                _itensService.Update(item);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Items = _estoqueService.GetAll(); // Carrega novamente os itens do estoque para a view
            return View(retiradaEstoque);
        }
        // Outros métodos conforme necessário (Edit, Delete, etc.)
    }
}