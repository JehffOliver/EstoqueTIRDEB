using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Models
{
    public class RetiradaEstoque
    {
        public int Id { get; set; }
        public int ItemId { get; set; } // ID do item retirado
        public int QuantidadeRetirada { get; set; } // Quantidade do item retirado
        public DateTime DataHoraRetirada { get; set; } // Data e hora da retirada

        public RetiradaEstoque(int id, int itemId, int quantidadeRetirada, DateTime dataHoraRetirada)
        {
            Id = id;
            ItemId = itemId;
            QuantidadeRetirada = quantidadeRetirada;
            DataHoraRetirada = dataHoraRetirada;
        }
    }
}
