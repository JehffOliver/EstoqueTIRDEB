using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Models
{
    public class EntradaEstoque
    {

        public int Id { get; set; }
        public DateTime DataEntrada { get; set; }
        public int Quantidade { get; set; }
        public int ItemId { get; set; }
        public Itens Item { get; set; }

        public EntradaEstoque()
        {
        }

        public EntradaEstoque(int id, DateTime dataEntrada, int quantidade, int itemId, Itens item)
        {
            Id = id;
            DataEntrada = dataEntrada;
            Quantidade = quantidade;
            ItemId = itemId;
            Item = item;
        }
    }
}

