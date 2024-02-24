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

        public RetiradaEstoqueController(RetiradaEstoqueService retiradaEstoqueService, ItensService itensService)
        {
            _retiradaEstoqueService = retiradaEstoqueService;
            _itensService = itensService;
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
                retiradaEstoque.DataHoraRetirada = DateTime.Now;
                _retiradaEstoqueService.Create(retiradaEstoque);
                return RedirectToAction(nameof(Index));
            }
            return View(retiradaEstoque);
        }

        // Outros métodos conforme necessário (Edit, Delete, etc.)
    }
}