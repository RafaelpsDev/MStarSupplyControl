using MStarSupplyControl.IoC.DTOs;

namespace MStarSupplyControl.IoC.Interfaces
{
    public interface IMercadoriaService
    {
        Task<bool> RegistrarMercadoria(MercadoriaDTO mercadoriaDTO);
        List<int> ObterIdDeTodasAsMercadorias();
        List<MercadoriaDTO> ObterTodasAsMercadorias();
    }
}
