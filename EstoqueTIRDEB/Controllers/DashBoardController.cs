using EstoqueTIRDEB.Data;
using EstoqueTIRDEB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly ItensService _itensService;
        private readonly EstoqueService _estoqueservice;
        private readonly CategoriaService _categoriaService;
        private readonly EstoqueTIRDEBContext _context;

        // Construtor que aceita as dependências necessárias
        public DashBoardController(ItensService itensService, EstoqueService estoqueService, CategoriaService categoriaService, EstoqueTIRDEBContext context)
        {
            _itensService = itensService;
            _estoqueservice = estoqueService;
            _categoriaService = categoriaService;
            _context = context;
        }

        // GET: DashBoard
        public ActionResult Index()
        {
            var itens = _itensService.FindAll(); // Ou algum outro método para obter os itens do estoque
            return View("Index", itens); // Passando a lista de itens para a view Index
        }

        // GET: DashBoard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashBoard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DashBoard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashBoard/Edit/5
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

        // GET: DashBoard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashBoard/Delete/5
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
