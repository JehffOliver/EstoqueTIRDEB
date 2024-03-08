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

            Categoria c1 = new Categoria(1, "Desktop");
            Categoria c2 = new Categoria(2, "Notebook");
            Categoria c3 = new Categoria(3, "Leitor de Código de Barras c/ fio");
            Categoria c4 = new Categoria(4, "Leitor de Código de Barras s/ fio");
            Categoria c5 = new Categoria(5, "Scanner de mesa");
            Categoria c6 = new Categoria(6, "Scanner de mão");
            Categoria c7 = new Categoria(7, "Impressora");
            Categoria c8 = new Categoria(8, "Monitor");
            Categoria c9 = new Categoria(9, "Caixinha de Som");
            Categoria c10 = new Categoria(10, "Tablet");
            Categoria c11 = new Categoria(11, "Projetor");
            Categoria c12 = new Categoria(12, "Web Cam");
            Categoria c13 = new Categoria(13, "HeadSet");
            Categoria c14 = new Categoria(14, "Switch");
            Categoria c15 = new Categoria(15, "AP");
            Categoria c16 = new Categoria(16, "APC NoBreak");
            Categoria c17 = new Categoria(17, "Estabilizador");


            _context.Categoria.AddRange(c1, c2, c3, c4);

            _context.SaveChanges();
        }
    }
}
