using Microsoft.AspNetCore.Mvc;
using MStarSupplyControl.IoC.DTOs;
using MStarSupplyControl.IoC.Interfaces;
using System;
using System.Threading.Tasks;

namespace MStarSupplyControl.Mvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISessao _sessao;
        private readonly IUsuarioService _usuarioService;
        public LoginController(ISessao sessao, IUsuarioService usuarioService)
        {
            _sessao = sessao;
            _usuarioService = usuarioService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public async Task<IActionResult> Entrar(UsuarioDTO usuarioDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = await _usuarioService.ObterUsuario(usuarioDTO);
                    _sessao.CriarSessaoDoUsuario(usuario);
                    return RedirectToAction("Index", "Home");
                }

                return View("Index");
            }
            catch (Exception erro)
            {

                TempData["Erro"] = $"Não conseguimos realizar seu login, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
