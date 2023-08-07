using MStarSupplyControl.IoC.DTOs;

namespace MStarSupplyControl.IoC.Interfaces
{
    public interface IGerenciamentoService
    {
        Task<bool> RegistrarEntrada(GerenciamentoEntradaDTO estoqueEntradaDTO);
        Task<bool> RegistrarSaida(GerenciamentoSaidaDTO estoqueSaidaDTO);
        List<string> ObterNomeDeTodasMercadorias();
        Task<int> ObterIdDaMercadoriasPeloNome(string mercadoria);
    }
}
