using EstoqueTIRDEB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Services
{
    public class EstoqueService
    {
        private readonly EstoqueTIRDEBContext _context;

        public EstoqueService(EstoqueTIRDEBContext dbContext)
        {
            _context = dbContext;
        }

        public void AdicionarItemAoEstoque(int itemId, int quantidade)
        {
            // Lógica para adicionar o item ao estoque
            var es = _context.EntradaeSaidas.FirstOrDefault(i => i.Id == itemId);

            if (es != null)
            {
                es.Quantidade  += quantidade;
                _context.SaveChanges();
            }
        }

        public void RemoverItemDoEstoque(int itemId, int quantidade)
        {
            // Lógica para remover o item do estoque
            var es = _context.EntradaeSaidas.FirstOrDefault(i => i.Id == itemId);

            if (es != null)
            {
                es.Quantidade -= quantidade;
                _context.SaveChanges();
            }
        }
    }
}