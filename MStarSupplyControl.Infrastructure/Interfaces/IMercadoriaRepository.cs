using MStarSupplyControl.Domain.Entities;

namespace MStarSupplyControl.Infrastructure.Interfaces
{
    public interface IMercadoriaRepository
    {
        Task<bool> CadastrarMercadoria(MercadoriaEntity mercadoriaEntity);
        List<string> ObterNomeDeTodasMercadorias();
        Task<int> ObterIdDaMercadoriasPeloNome(string Mercadoria);
        List<int> ObterIdDeTodasAsMercadorias();
        List<MercadoriaEntity> ObterTodasAsMercadorias();
    }
}
