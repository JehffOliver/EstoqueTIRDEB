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

        [Required(ErrorMessage = "O campo Modelo é obrigatório.")]
        public string Modelo { get; set; }

        [Display(Name = "Fabricante")]
        public string Fabricante { get; set; }

        [Display(Name = "CD")]
        public string CD { get; set; }

        [Display(Name = "Nota Fiscal")]
        public string NotaFiscal { get; set; }

        [Display(Name = "Equipamento")]
        public string Equipamento { get; set; }

        [Display(Name = "Número de Série")]
        public string NumeroSerie { get; set; }

        [Display(Name = "Patrimônio")]
        public string Patrimonio { get; set; }

        [Display(Name = "Sistema Operacional")]
        public string SistemaOperacional { get; set; }

        [Display(Name = "Departamento/Setor")]
        public string DepartamentoSetor { get; set; }

        [Display(Name = "Hostname")]
        public string Hostname { get; set; }

        [Required(ErrorMessage = "O campo Data de Aquisição é obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime DataAquisicao { get; set; }

        // Propriedade calculada para tempo aproximado de uso em dias
        public int TempoAproximadoDeUso
        {
            get
            {
                TimeSpan tempoDeUso = DateTime.Today - DataAquisicao.Date;
                return tempoDeUso.Days;
            }
        }

        [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser um valor positivo.")]
        public int Quantidade { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public Itens()
        {
        }

        public Itens(int id, string nome, string modelo, string fabricante, string equipamento, string numeroSerie, string especificações, string patrimonio, string sistemaOperacional, string departamentoSetor, string hostname, DateTime dataAquisicao, int quantidade, int categoriaId, Categoria categoria) : this(id, modelo)
        {
            Equipamento = equipamento;
            NumeroSerie = numeroSerie;
            Patrimonio = patrimonio;
            SistemaOperacional = sistemaOperacional;
            DepartamentoSetor = departamentoSetor;
            Hostname = hostname;
            DataAquisicao = dataAquisicao;
            Quantidade = quantidade;
            CategoriaId = categoriaId;
            Categoria = categoria;
        }

        public Itens(int id, string modelo)
        {
            Id = id;
            Modelo = modelo;
        }

        

    }
}



