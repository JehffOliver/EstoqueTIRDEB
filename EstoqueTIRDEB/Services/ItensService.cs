using EstoqueTIRDEB.Data;
using EstoqueTIRDEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _context.Itens.ToList();
        }

        public void Insert(Itens obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
