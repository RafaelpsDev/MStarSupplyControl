using Microsoft.AspNetCore.Mvc;
using MStarSupplyControl.IoC.DTOs;
using MStarSupplyControl.IoC.Interfaces;
using System;
using System.Threading.Tasks;

namespace MStarSupplyControl.Mvc.Controllers
{
    public class GerenciamentoController : Controller
    {
        private readonly IGerenciamentoService _gerenciamentoService;
        private readonly IMercadoriaService _mercadoriaService;
        public GerenciamentoController(IGerenciamentoService gerenciamentoService, IMercadoriaService mercadoriaService)
        {
            _gerenciamentoService = gerenciamentoService;
            _mercadoriaService = mercadoriaService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RegistrarEntrada()
        {
            ViewBag.DataAtual = DateTime.Now;
            return View("RegistrarEntrada");
        }
        public IActionResult RegistrarSaida()
        {
            ViewBag.DataAtual = DateTime.Now;
            return View("RegistrarSaida");
        }
        [HttpPost]
        public async Task<IActionResult> RegistrarEntrada(GerenciamentoEntradaDTO estoqueEntradaDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _gerenciamentoService.RegistrarEntrada(estoqueEntradaDTO);
                    TempData["Sucesso"] = $"Entrada registrada com sucesso.";
                    return View("Index");

                }
                return View("Index");
            }
            catch (Exception erro)
            {

                TempData["Erro"] = $"Entrada não registrada, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> RegistrarSaida(GerenciamentoSaidaDTO estoqueSaidaDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _gerenciamentoService.RegistrarSaida(estoqueSaidaDTO);
                    TempData["Sucesso"] = $"Saída registrada com sucesso.";
                    return View("Index");

                }
                return View("Index");
            }
            catch (Exception erro)
            {

                TempData["Erro"] = $"Saída não registrada, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Gerenciamento()
        {
            return View("Gerenciamento");
        }
        
        [HttpGet]
        [Route("/Gerenciamento/ObterMercadorias")]
        public IActionResult ObterMercadorias()
        {
            var mercadorias = _gerenciamentoService.ObterNomeDeTodasMercadorias();
            return Json(mercadorias);
        }

        public IActionResult Mercadorias()
        {
            var mercadorias = _mercadoriaService.ObterTodasAsMercadorias();
            return View(mercadorias);
        }

    }
}
