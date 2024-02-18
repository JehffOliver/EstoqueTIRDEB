using EstoqueTIRDEB.Data;
using EstoqueTIRDEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Services
{
    public class SeedingService
    {
        private readonly EstoqueTIRDEBContext _context;

        public SeedingService(EstoqueTIRDEBContext context)
        {
            _context = context;
        }


        public void Seed()
        {
            if (_context.Categoria.Any())
            {
                return; // Categorias populadas.
            }

            Categoria c1 = new Categoria(1, "Periféricos");
            Categoria c2 = new Categoria(2, "Hardware");
            Categoria c3 = new Categoria(3, "Computadores");
            Categoria c4 = new Categoria(4, "Impressoras");


            _context.Categoria.AddRange(c1, c2, c3, c4);

            _context.SaveChanges();
        }
    }
}
