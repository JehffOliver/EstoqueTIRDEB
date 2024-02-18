using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Models.ViewModels
{
    public class AdicionarItemViewModel
    {
        public int ItemId { get; set; } // ID do item
        public int Quantidade { get; set; } // Quantidade a ser adicionada ao estoque
        public string Nome { get; set; } // Nome do item
        public string Modelo { get; set; } // Modelo do item
        public string Especificacoes { get; set; } // Especificações do item
        public DateTime DataAquisicao { get; set; } // Data de aquisição do item
    }
}
