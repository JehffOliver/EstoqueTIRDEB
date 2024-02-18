using EstoqueTIRDEB.Data;
using System;
using EstoqueTIRDEB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueTIRDEB.Models.ViewModels;

namespace EstoqueTIRDEB.Services
{
    public class EstoqueService
    {
        private readonly EstoqueTIRDEBContext _context;

        public EstoqueService(EstoqueTIRDEBContext context)
        {
            _context = context;
        }

        public AdicionarItemViewModel GetDetalhesQuantidadeViewModel(int itemId)
        {
            var item = _context.Itens.Find(itemId);

            if (item == null)
            {
                return null;
            }

            var viewModel = new AdicionarItemViewModel
            {
                Item = item,
                EntradasEstoque = _context.EntradaEstoque.Where(es => es.ItemId == itemId).ToList()
            };

            return viewModel;
        }

        public int CalcularQuantidadeEmEstoque(int itemId)
        {
            return _context.EntradaEstoque.Where(es => es.ItemId == itemId).Sum(es => es.Quantidade);
        }
    }
}