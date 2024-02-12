using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Models
{

    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Itens> Iten { get; set; } = new List<Itens>();

        public Categoria()
        {
        }

        public Categoria(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddItem(Itens Itens)
        {
            Iten.Add(Itens);
        }

        public void RemoveItem(Itens Itens)
        {
            Iten.Remove(Itens);
        }


        public double TotalItes(DateTime inicio, DateTime fim)
        {
            return Iten.Sum(Iten => Iten.TotalItens(inicio, fim));
        }

    }
}

