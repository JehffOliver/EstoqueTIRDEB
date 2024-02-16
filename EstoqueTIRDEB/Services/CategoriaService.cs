using EstoqueTIRDEB.Data;
using EstoqueTIRDEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Services
{
    public class CategoriaService
    {
        private readonly EstoqueTIRDEBContext _context;

        public CategoriaService(EstoqueTIRDEBContext context)
        {
            _context = context;
        }

        public List<Categoria> FindAll()
        {
            return _context.Categoria.OrderBy(x => x.Nome).ToList();
        }
    }
}
