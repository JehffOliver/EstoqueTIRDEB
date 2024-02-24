using EstoqueTIRDEB.Models;
using System.Collections.Generic;

namespace EstoqueTIRDEB.ViewModels
{
    public class RetiradaEstoqueViewModel
    {
        public IEnumerable<RetiradaEstoque> RetiradasEstoque { get; set; }
        public List<Itens> Itens { get; set; }
        public List<RetiradaEstoque> RegistrosRetiradaEstoque { get; set; }
    }
}