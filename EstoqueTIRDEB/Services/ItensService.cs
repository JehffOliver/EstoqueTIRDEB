using EstoqueTIRDEB.Data;
using EstoqueTIRDEB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EstoqueTIRDEB.Services
{
    public class ItensService
    {
        private readonly EstoqueTIRDEBContext _context;

        public ItensService(EstoqueTIRDEBContext context)
        {
            _context = context;
        }

        public List<Itens> FindAll()
        {
            return _context.Itens.Include(i => i.Categoria).ToList();
        }

        public Itens FindById(int id)
        {
            return _context.Itens.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Itens.Find(id);
            if (obj != null)
            {
                _context.Itens.Remove(obj);
                _context.SaveChanges();
            }
        }

        public void Insert(Itens obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public List<Itens> ListarPorCategoria(int categoriaId)
        {
            return _context.Itens.Where(i => i.CategoriaId == categoriaId).ToList();
        }

        public void AdicionarItemAoEstoque(Itens item, int categoriaId)
        {
            var categoria = _context.Categoria.Find(categoriaId);
            if (categoria != null)
            {
                item.CategoriaId = categoriaId;
                _context.Itens.Add(item);
                _context.SaveChanges();
            }
            else
            {
                // Tratar erro de categoria não encontrada
            }
        }
    }
}