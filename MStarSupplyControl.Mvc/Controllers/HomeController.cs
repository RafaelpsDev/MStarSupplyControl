using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MStarSupplyControl.IoC.Interfaces;
using MStarSupplyControl.Mvc.Models;
using System.Diagnostics;

namespace MStarSupplyControl.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGerenciamentoService _gerenciamentoService;



        public HomeController(ILogger<HomeController> logger, IGerenciamentoService gerenciamentoService)
        {
            _logger = logger;
            _gerenciamentoService = gerenciamentoService;
        }

        public IActionResult Index()
        {
            var mercadorias = _gerenciamentoService.ObterNomeDeTodasMercadorias();
            return View(mercadorias);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}