using Microsoft.AspNetCore.Mvc;
using MStarSupplyControl.IoC.DTOs;
using MStarSupplyControl.IoC.Interfaces;
using System;
using System.Threading.Tasks;

namespace MStarSupplyControl.Mvc.Controllers
{
    public class MercadoriaController : Controller
    {
        private readonly IMercadoriaService _mercadoriaService;

        public MercadoriaController(IMercadoriaService mercadoriaService)
        {
            _mercadoriaService = mercadoriaService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CadastrarMercadoria()
        {
            return View("CadastrarMercadoria");            
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarMercadoria(MercadoriaDTO mercadoriaDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mercadoriaService.RegistrarMercadoria(mercadoriaDTO);
                    TempData["Sucesso"] = $"Mercadoria inserida com sucesso.";
                    return View("Index");

                }
                return View("Index");
            }
            catch (Exception erro)
            {

                TempData["Erro"] = $"Mercadoria não cadastrada, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }


    }
}
