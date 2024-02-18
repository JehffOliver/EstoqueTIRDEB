using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    namespace EstoqueTIRDEB.Models
    {
        public class Itens
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Modelo { get; set; }
            public string Especificações { get; set; }
            public DateTime DataAquisicao { get; set; }
            public int CategoriaId { get; set; }
            public List<EntradaEstoque> EntradasEstoque { get; set; } = new List<EntradaEstoque>();

        public Itens()
            {
            }

            public Itens(int id, string nome, string modelo, string especificações)
            {
                Id = id;
                Nome = nome;
                Modelo = modelo;
                Especificações = especificações;
            }

        }
    }



