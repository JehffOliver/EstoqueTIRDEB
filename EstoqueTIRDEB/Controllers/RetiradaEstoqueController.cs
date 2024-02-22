using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EstoqueTIRDEB.Models;
using EstoqueTIRDEB.Services;

namespace EstoqueTIRDEB.Controllers
{
    public class RetiradaEstoqueController : Controller
    {
        private readonly EstoqueService _estoqueService;
        private readonly RetiradaEstoqueService _retiradaEstoqueService;

        public RetiradaEstoqueController(EstoqueService estoqueService, RetiradaEstoqueService retiradaEstoqueService)
        {
            _estoqueService = estoqueService;
            _retiradaEstoqueService = retiradaEstoqueService;
        }

        // GET: RetiradaEstoque
        public IActionResult Index()
        {
            var registrosRetiradaEstoque = _retiradaEstoqueService.GetAll();
            return View(registrosRetiradaEstoque);
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
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Items = _estoqueService.GetAll(); // Carrega novamente os itens do estoque para a view
            return View(retiradaEstoque);
        }

        // Outros métodos conforme necessário (Edit, Delete, etc.)
    }
}