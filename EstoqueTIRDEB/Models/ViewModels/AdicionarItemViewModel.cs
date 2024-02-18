using System;
using System.Collections.Generic;
using EstoqueTIRDEB.Models;

namespace EstoqueTIRDEB.Models.ViewModels
{
    public class AdicionarItemViewModel
    {
        public int ItemId { get; set; } // ID do item
        public List<EntradaEstoque> EntradasEstoque { get; set; } // Lista de entradas de estoque para o item
        public Itens Item { get; set; }
        public string Nome { get; set; } // Nome do item
        public string Modelo { get; set; } // Modelo do item
        public string Especificacoes { get; set; } // Especificações do item
        public DateTime DataAquisicao { get; set; } // Data de aquisição do item

        // Propriedade calculada para obter a quantidade total de entrada de estoque
        public int QuantidadeTotalEntrada
        {
            get
            {
                int quantidadeTotal = 0;
                if (EntradasEstoque != null)
                {
                    foreach (var entrada in EntradasEstoque)
                    {
                        quantidadeTotal += entrada.Quantidade;
                    }
                }
                return quantidadeTotal;
            }
        }
    }
}