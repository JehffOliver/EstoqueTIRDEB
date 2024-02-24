using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EstoqueTIRDEB.Models;

namespace EstoqueTIRDEB.Data
{
    public class EstoqueTIRDEBContext : DbContext
    {
        public EstoqueTIRDEBContext (DbContextOptions<EstoqueTIRDEBContext> options)
            : base(options)
        {
        }
        public DbSet<Itens> Itens { get; set; }
        public DbSet<EntradaEstoque> EntradaEstoque { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<RetiradaEstoque> RetiradasEstoque { get; set; }
        public DbSet<RetiradaEstoque> RetiradaEstoque { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações do modelo
        }
    }
}
