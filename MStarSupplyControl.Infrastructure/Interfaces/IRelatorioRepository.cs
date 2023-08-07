using MStarSupplyControl.Domain.Entities;

namespace MStarSupplyControl.Infrastructure.Interfaces
{
    public interface IRelatorioRepository
    {
        List<RelatorioEntity> ObterTotalParaRelatorioPdf();
        List<RelatorioEntity> ObterTotalParaRelatorioGrafico(string Mercadoria);
    }
}
