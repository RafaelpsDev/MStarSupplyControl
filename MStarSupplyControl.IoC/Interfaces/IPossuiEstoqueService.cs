
namespace MStarSupplyControl.IoC.Interfaces
{
    public interface IPossuiEstoqueService
    {
        Task<bool> PossuiEstoque(int quantidade, string mercadoria);
    }
}
