using EstoqueTIRDEB.Data;
using EstoqueTIRDEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Ropositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly EstoqueTIRDEBContext _context;

        public UsuarioRepositorio(EstoqueTIRDEBContext estoque)
        {
            _context = estoque;
        }

        public Usuario BuscarPorLogin(string login)
        {
            return _context.Usuario.FirstOrDefault(x => x.NomeUsuario.ToUpper() == login.ToUpper());
        } 
    }
}
