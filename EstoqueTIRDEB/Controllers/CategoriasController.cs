using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstoqueTIRDEB.Data;
using EstoqueTIRDEB.Models;
using EstoqueTIRDEB.Services;

namespace EstoqueTIRDEB.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly EstoqueTIRDEBContext _context;
        private readonly ItensService _itensService;
        private readonly CategoriaService _categoriaService;

        public CategoriasController(EstoqueTIRDEBContext context, ItensService itensService)
        {
            _context = context;
            _itensService = itensService;
        }

        public IActionResult Create()
        {
            var categorias = _categoriaService.GetAll(); // ou qualquer outra lógica para obter as categorias

            ViewBag.Categorias = new SelectList(categorias, "Id", "Nome"); // substitua "Id" e "Nome" pelos nomes das propriedades da sua classe Categoria

            return View();
        }

        // POST: /Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                // Aqui você pode chamar o método estático AdicionarCategoria da classe Categoria
                Categoria novaCategoria = Categoria.AdicionarCategoria(categoria.Nome);

                // Lógica para persistir a nova categoria no banco de dados
                // Exemplo com o Entity Framework:
                // _context.Categorias.Add(novaCategoria);
                // _context.SaveChanges();

                return RedirectToAction("Index"); // Redireciona para a página de índice após criar a categoria com sucesso
            }
            return View(categoria); // Se houver erros de validação, retorna para a view com os dados inseridos pelo usuário
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categoria.ToListAsync());
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
            _itensService.AdicionarItemAoEstoque(item, categoriaId);
            return RedirectToAction("Index", "Home"); // Ou outra ação desejada
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categoria.Any(e => e.Id == id);
        }
    }
}
