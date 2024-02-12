using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Models
{
    public class EntradaeSaida
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantidade { get; set; }
        public Itens Itens { get; set; }

        public EntradaeSaida()
        {
        }

        public EntradaeSaida(int id, DateTime date, int quantidade, Itens itens)
        {
            Id = id;
            Date = date;
            Quantidade = quantidade;
            Itens = itens;
        }
    }
}

