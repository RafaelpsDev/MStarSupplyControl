using MStarSupplyControl.Domain.Entities;

namespace MStarSupplyControl.Infrastructure.Interfaces
{
    public interface IGerenciamentoRepository
    {
        Task<bool> RegistrarEntrada(EntradaEntity entradaEntity);
        Task<bool> RegistrarSaida(SaidaEntity saidaEntity);
        Task<int> ObterQuantidade(string mercadoria);
    }
}
