using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Models
{
    public class EntradaeSaida
    {

        public int Id { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int Quantidade { get; set; }
        public Itens Itens { get; set; }

        public EntradaeSaida()
        {
        }

        public EntradaeSaida(int id, DateTime dataEntrada, DateTime dataSaida, int quantidade, Itens itens)
        {
            Id = id;
            DataEntrada = dataEntrada;
            DataSaida = dataSaida;
            Quantidade = quantidade;
            Itens = itens;
        }
    }
}

