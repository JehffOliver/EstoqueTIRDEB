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
            _context.RetiradaEstoque.Add(retiradaEstoque);
            _context.SaveChanges();
        }

        // Outros métodos conforme necessário (Update, Delete, etc.)
    }
}