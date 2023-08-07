using MStarSupplyControl.Infrastructure.Interfaces;
using MStarSupplyControl.IoC.Interfaces;

namespace MStarSupplyControl.Application.Services
{    
    public class PossuiEstoqueService : IPossuiEstoqueService
    {
        private readonly IGerenciamentoRepository _gerenciamentoRepository;
        public PossuiEstoqueService(IGerenciamentoRepository gerenciamentoRepository)
        {
            _gerenciamentoRepository = gerenciamentoRepository;
        }
        public async Task<bool> PossuiEstoque(int quantidade, string mercadoria)
        {
            var estoque = await _gerenciamentoRepository.ObterQuantidade(mercadoria);
            if (quantidade > estoque)
                throw new Exception("A quantidade informada é maior que a quantidade em estoque");
            return true;
        }
    }
}
