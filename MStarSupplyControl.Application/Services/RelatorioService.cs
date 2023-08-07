using MStarSupplyControl.Infrastructure.Interfaces;
using MStarSupplyControl.IoC.DTOs;
using MStarSupplyControl.IoC.Interfaces;


namespace MStarSupplyControl.Application.Services
{    
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepository;
        private readonly IRelatorioAdapter _relatorioAdapter;
        public RelatorioService(IRelatorioRepository relatorioRepository, IRelatorioAdapter relatorioAdapter)
        {
            _relatorioRepository = relatorioRepository;
            _relatorioAdapter = relatorioAdapter;

        }

        public List<ResponseRelatorioMensalDTO> ObterTotalParaRelatorioGrafico(string Mercadoria)
        {
            var relatorioGrafico = _relatorioRepository.ObterTotalParaRelatorioGrafico(Mercadoria);
            var retorno = _relatorioAdapter.ToResponseRelatorioMensalDTO(relatorioGrafico);
            return retorno;
        }

        public List<ResponseRelatorioMensalDTO> ObterTotalParaRelatorioPdf()
        {
            var relatorioPdf = _relatorioRepository.ObterTotalParaRelatorioPdf();
            var retorno = _relatorioAdapter.ToResponseRelatorioMensalDTO(relatorioPdf);
            return retorno;
        }

      
    }
}
