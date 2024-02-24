using EstoqueTIRDEB.Models;
using System.Collections.Generic;

namespace EstoqueTIRDEB.ViewModels
{
    public class RetiradaEstoqueViewModel
    {
        public IEnumerable<RetiradaEstoque> RetiradasEstoque { get; set; }
        public IEnumerable<Itens> Itens { get; set; }
    }
}