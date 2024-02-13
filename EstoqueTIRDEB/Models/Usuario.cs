using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo Nome de Usuário é obrigatório.")]
        [Display(Name = "Nome de Usuário")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public Usuario()
        {
        }

        public Usuario(int usuarioId, string nomeUsuario, string senha)
        {
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            Senha = senha;
        }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}

