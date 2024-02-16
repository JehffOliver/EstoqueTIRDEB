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
            public Categoria Categoria { get; set; }
            public int CategoriaId { get; set; }
            public ICollection<EntradaeSaida> EntradaeSaidas { get; set; } = new List<EntradaeSaida>();

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


            public void AddEs(EntradaeSaida es)
            {
                EntradaeSaidas.Add(es);
            }

            public void RemoveEs(EntradaeSaida es)
            {
                EntradaeSaidas.Remove(es);
            }

            public double TotalItens(DateTime initial, DateTime final)
            {
                return EntradaeSaidas.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Quantidade);
            }


        }
    }



