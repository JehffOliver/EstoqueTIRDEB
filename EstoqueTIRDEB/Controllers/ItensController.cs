﻿using CsvHelper;
using CsvHelper.Configuration;
using EstoqueTIRDEB.Data;
using EstoqueTIRDEB.Models;
using EstoqueTIRDEB.Models.ViewModels;
using EstoqueTIRDEB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Controllers
{
    public class ItensController : Controller
    {

        private readonly ItensService _itensService;
        private readonly EstoqueService _estoqueservice;
        private readonly CategoriaService _categoriaService;
        private readonly EstoqueTIRDEBContext _context;
        private readonly RetiradaEstoqueService _retiradaEstoqueService;
        private readonly ExcelService _excelService;

        // Construtor que aceita as dependências necessárias
        public ItensController(ItensService itensService, EstoqueService estoqueService, CategoriaService categoriaService, EstoqueTIRDEBContext context, RetiradaEstoqueService retiradaEstoqueService, ExcelService excelService)
        {
            _itensService = itensService;
            _estoqueservice = estoqueService;
            _categoriaService = categoriaService;
            _context = context;
            _retiradaEstoqueService = retiradaEstoqueService;
            _excelService = excelService;
        }

        // GET: ItensController
        public ActionResult Index()
        {
            var itensComCategorias = _itensService.FindAllWithCategoria(); // Método para carregar os itens com suas categorias

            return View(itensComCategorias);
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
        public IActionResult Create(Itens itens, int quantidade)
        {
            if (ModelState.IsValid)
            {
                // Define a quantidade inicial do item
                itens.Quantidade = quantidade;

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
            var item = _itensService.FindById(id);
            if (item == null)
            {
                return NotFound();
            }

            var categorias = _categoriaService.GetAll(); // Carregar todas as categorias disponíveis
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nome", item.CategoriaId); // Passar as categorias para a view

            return View(item);
        }

        // POST: ItensController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Itens item, int quantidade)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Atualiza a quantidade do item
                    item.Quantidade = quantidade;
                    _itensService.Update(item);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    // Se ocorrer algum erro ao atualizar, recarrega a lista de categorias e retorna a view com o item
                    var categorias = _categoriaService.GetAll();
                    ViewBag.Categorias = new SelectList(categorias, "Id", "Nome", item.CategoriaId);
                    return View(item);
                }
            }

            // Se o modelo não for válido, recarrega a lista de categorias e retorna a view com o item
            var categoriasInvalidas = _categoriaService.GetAll();
            ViewBag.Categorias = new SelectList(categoriasInvalidas, "Id", "Nome", item.CategoriaId);
            return View(item);
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

        // Outros métodos do controller

        // GET: Itens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Itens.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Itens/RetirarQuantidade/5
        public async Task<IActionResult> RetirarQuantidade(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Itens.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Itens/RetirarQuantidade/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RetirarQuantidade(int id, int quantidadeRetirada)
        {
            var item = await _context.Itens.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            if (quantidadeRetirada <= item.Quantidade)
            {
                item.Quantidade -= quantidadeRetirada;
                await _context.SaveChangesAsync();

                // Criar um registro de retirada de estoque
                var retiradaEstoque = new RetiradaEstoque
                {
                    ItemId = item.Id,
                    QuantidadeRetirada = quantidadeRetirada,
                    DataHoraRetirada = DateTime.Now
                };
                _context.RetiradaEstoque.Add(retiradaEstoque);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Retornar uma mensagem de erro informando que a quantidade a ser retirada é maior do que a quantidade disponível
                ModelState.AddModelError(string.Empty, "A quantidade a ser retirada é maior do que a quantidade disponível.");
                return View(item);
            }
        }

        [HttpGet]
        public IActionResult UploadExcel()
        {
            return View("UploadExcel");
        }

        [HttpPost]
        public async Task<IActionResult> UploadExcel(IFormFile excelFile)
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                return Content("Arquivo não selecionado");
            }

            using (var reader = new StreamReader(excelFile.OpenReadStream()))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",",
                    HasHeaderRecord = true // Se a primeira linha contém o cabeçalho
                };

                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<Itens>();

                    foreach (var item in records)
                    {
                        if (ModelState.IsValid)
                        {
                            _itensService.Insert(item);
                        }
                        else
                        {
                            var categorias = _categoriaService.GetAll();
                            ViewBag.Categorias = new SelectList(categorias, "Id", "Nome", item.CategoriaId);
                            return View("Create", item);
                        }
                    }
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
