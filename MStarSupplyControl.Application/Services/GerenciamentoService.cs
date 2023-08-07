using MStarSupplyControl.Infrastructure.Interfaces;
using MStarSupplyControl.IoC.DTOs;
using MStarSupplyControl.IoC.Interfaces;
using System.Globalization;

namespace MStarSupplyControl.Application.Services
{
    public class GerenciamentoService : IGerenciamentoService
    {
        private readonly IGerenciamentoAdapter _gerenciamentoAdapter;
        private readonly IGerenciamentoRepository _gerenciamentoRepository;
        private readonly IMercadoriaRepository _mercadoriaRepository;
        private readonly IPossuiEstoqueService _possuiEstoqueService;
        public GerenciamentoService(IGerenciamentoAdapter gerenciamentoAdapter, IGerenciamentoRepository gerenciamentoRepository, IMercadoriaRepository mercadoriaRepository, IPossuiEstoqueService possuiEstoqueService)
        {
            _gerenciamentoAdapter = gerenciamentoAdapter;
            _gerenciamentoRepository = gerenciamentoRepository;
            _mercadoriaRepository = mercadoriaRepository;
            _possuiEstoqueService = possuiEstoqueService;

        }

        public async Task<int> ObterIdDaMercadoriasPeloNome(string Mercadoria)
        {
            var idMercadoria = await _mercadoriaRepository.ObterIdDaMercadoriasPeloNome(Mercadoria);
            return idMercadoria;
        }

        public List<string> ObterNomeDeTodasMercadorias()
        {
            return _mercadoriaRepository.ObterNomeDeTodasMercadorias();
        }

        public async Task<bool> RegistrarEntrada(GerenciamentoEntradaDTO gerenciamentoEntradaDTO)
        {
            var idMercadoria = await _mercadoriaRepository.ObterIdDaMercadoriasPeloNome(gerenciamentoEntradaDTO.Mercadoria);

            string dataFormatada = gerenciamentoEntradaDTO.DataDeEntrada.ToString("yyyy-MM-dd");
            
            var toEntity = _gerenciamentoAdapter.ToGerenciamentoEntityEntrada(gerenciamentoEntradaDTO);
            toEntity.IdMercadoria = idMercadoria;
            toEntity.DataDeEntrada = DateTime.ParseExact(dataFormatada, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            await _gerenciamentoRepository.RegistrarEntrada(toEntity);
            return true;
        }

        public async Task<bool> RegistrarSaida(GerenciamentoSaidaDTO gerenciamentoSaidaDTO)
        {
            if( await _possuiEstoqueService.PossuiEstoque(gerenciamentoSaidaDTO.Quantidade, gerenciamentoSaidaDTO.Mercadoria) == false)
                return false;

                var idMercadoria = await _mercadoriaRepository.ObterIdDaMercadoriasPeloNome(gerenciamentoSaidaDTO.Mercadoria);
            string dataFormatada = gerenciamentoSaidaDTO.DataDeSaida.ToString("yyyy-MM-dd");

            var toEntity = _gerenciamentoAdapter.ToGerenciamentoEntitySaida(gerenciamentoSaidaDTO);
            toEntity.IdMercadoria = idMercadoria;
            toEntity.DataDeSaida = DateTime.ParseExact(dataFormatada, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            await _gerenciamentoRepository.RegistrarSaida(toEntity);
            return true;
        }
    }
}
