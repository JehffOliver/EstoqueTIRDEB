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
            var registrosRetiradaEstoque = _retiradaEstoqueService.GetAll();
            var viewModel = new RetiradaEstoqueViewModel
            {
                RetiradasEstoque = registrosRetiradaEstoque.ToList(),
                Itens = _itensService.GetAll().ToList() // Convertendo para List<Itens>
            };

            return View(viewModel);
        }

        // GET: RetiradaEstoque/Create
        public IActionResult Create()
        {
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

                // Verifica se a quantidade a ser retirada é válida
                var item = _itensService.GetById(retiradaEstoque.ItemId);
                if (item != null && item.Quantidade >= retiradaEstoque.QuantidadeRetirada)
                {
                    // Atualiza a quantidade do item no estoque
                    item.Quantidade -= retiradaEstoque.QuantidadeRetirada;
                    _itensService.Update(item);

                    // Cria o registro de retirada de estoque
                    _retiradaEstoqueService.Create(retiradaEstoque);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Retorna uma mensagem de erro se a quantidade for inválida
                    ModelState.AddModelError(string.Empty, "Quantidade insuficiente no estoque para realizar a retirada.");
                }
            }

            ViewBag.Items = _estoqueService.GetAll(); // Carrega novamente os itens do estoque para a view
            return View(retiradaEstoque);
        }
        // Outros métodos conforme necessário (Edit, Delete, etc.)
    }
}