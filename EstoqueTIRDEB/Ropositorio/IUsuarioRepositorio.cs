using EstoqueTIRDEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueTIRDEB.Ropositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorLogin(string login);
    }
}
