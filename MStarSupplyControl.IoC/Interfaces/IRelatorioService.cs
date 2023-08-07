using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.IoC.DTOs;

namespace MStarSupplyControl.IoC.Interfaces
{
    public interface IRelatorioService
    {
        List<ResponseRelatorioMensalDTO> ObterTotalParaRelatorioPdf();
        List<ResponseRelatorioMensalDTO> ObterTotalParaRelatorioGrafico(string Mercadoria);
    }
}
