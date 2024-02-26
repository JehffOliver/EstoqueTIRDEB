using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstoqueTIRDEB.Data;
using EstoqueTIRDEB.Models;
using EstoqueTIRDEB.Ropositorio;
using Microsoft.AspNetCore.Http;
using EstoqueTIRDEB.Helper;

namespace EstoqueTIRDEB.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly EstoqueTIRDEBContext _context;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public UsuariosController(EstoqueTIRDEBContext context, IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _context = context;
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }



        // GET: Usuarios
        public async Task<IActionResult> Index()
        {

            //Se o usuario estiver logado, redirecionar para a home

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Usuarios");
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Buscar o usuário no banco de dados pelo nome de usuário
                    Usuario u = _usuarioRepositorio.BuscarPorLogin(usuario.NomeUsuario);

                    if (u != null)
                    {
                        // Comparar a senha fornecida com a senha armazenada no banco de dados
                        if (u.SenhaValida(usuario.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha inválida. Por favor tente novamente";

                        return RedirectToAction("Index", "Usuarios");
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválidos. Por favor tente novamente";

                }

                // Se as credenciais não forem válidas, retornar a mesma view de login
                return View("Index");
            }
            catch (Exception erro)
            {
                // Lidar com exceções, se necessário
                TempData["MensagemErro"] = $"Não foi possível realizar o login, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,NomeUsuario,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,NomeUsuario,Senha")] Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UsuarioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.UsuarioId == id);
        }
    }
}
