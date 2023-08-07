using Microsoft.AspNetCore.Mvc;
using MStarSupplyControl.IoC.Interfaces;
using Newtonsoft.Json;
using System;

namespace MStarSupplyControl.Mvc.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly IRelatorioService _relatorioService;
        private readonly IRelatorioPdfService _relatorioPdfService;
        public RelatorioController(IRelatorioService relatorioService, IRelatorioPdfService relatorioPdfService)
        {
            _relatorioService = relatorioService;
            _relatorioPdfService = relatorioPdfService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GraficoEntradaESaidaMensal()
        {
            return View("GraficoEntradaESaidaMensal");
        }
        [HttpGet]
        public IActionResult GerarRelatorioMensalPdf()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _relatorioPdfService.GerarRelatorioMensalPdf();
                    TempData["Sucesso"] = $"Relatório gerado com sucesso na pasta ArquivosPdf.";
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos gerar o relatório, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public IActionResult GraficoEntradaESaidaMensal(string mercadoria)
        {
            if (!string.IsNullOrEmpty(mercadoria))
            {
                ViewBag.Mercadoria = mercadoria;
                var dados = _relatorioService.ObterTotalParaRelatorioGrafico(mercadoria);
                // Converter os dados para uma representação JSON e passar para a View
                ViewBag.Dados = JsonConvert.SerializeObject(dados);
            }
            return View();
        }
    }
}


