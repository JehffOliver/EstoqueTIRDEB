using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Models
{
    public class Itens
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Modelo é obrigatório.")]
        public string Modelo { get; set; }

        public string Especificações { get; set; }

        [Required(ErrorMessage = "O campo Data de Aquisição é obrigatório.")]
        public DateTime DataAquisicao { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser um valor positivo.")]
        public int Quantidade { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
        
        public Itens()
        {
        }

        public Itens(int id, string nome, string modelo, string especificações)
        {
            Id = id;
            Nome = nome;
            Modelo = modelo;
            Especificações = especificações;
        }

    }
}



