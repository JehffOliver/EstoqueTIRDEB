using EstoqueTIRDEB.Data;
using EstoqueTIRDEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueTIRDEB.Services
{
    public class RetiradaEstoqueService
    {
        private readonly EstoqueTIRDEBContext _context;

        public RetiradaEstoqueService(EstoqueTIRDEBContext context)
        {
            _context = context;
        }

        public IEnumerable<RetiradaEstoque> GetAll()
        {
            return _context.RetiradaEstoque.ToList();
        }

        public void Create(RetiradaEstoque retiradaEstoque)
        {
            // Verifica se o item existe no banco de dados
            var item = _context.Itens.FirstOrDefault(i => i.Id == retiradaEstoque.ItemId);
            if (item != null)
            {
                // Atualiza a quantidade do item
                item.Quantidade -= retiradaEstoque.QuantidadeRetirada;

                // Adiciona a retirada de estoque ao contexto
                _context.RetiradaEstoque.Add(retiradaEstoque);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("O item associado à retirada de estoque não foi encontrado.");
            }
        }

        public Itens GetById(int id)
        {
            return _context.Itens.FirstOrDefault(i => i.Id == id);
        }

        // Outros métodos conforme necessário (Update, Delete, etc.)
    }
}