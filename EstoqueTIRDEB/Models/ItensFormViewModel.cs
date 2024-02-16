using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Models
{
    public class ItensFormViewModel
    {
        public Itens Itens { get; set; }
        public ICollection<Categoria> Categoria { get; set; }
    }
}
