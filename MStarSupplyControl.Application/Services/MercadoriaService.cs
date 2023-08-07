using MStarSupplyControl.Infrastructure.Interfaces;
using MStarSupplyControl.IoC.DTOs;
using MStarSupplyControl.IoC.Interfaces;

namespace MStarSupplyControl.Application.Services
{
    public class MercadoriaService : IMercadoriaService
    {
        private readonly IMercadoriaRepository _mercadoriaRepository;
        private readonly IMercadoriaAdapter _mercadoriaAdapter;

        public MercadoriaService(IMercadoriaRepository mercadoriaRepository, IMercadoriaAdapter mercadoriaAdapter)
        {
            _mercadoriaRepository = mercadoriaRepository;
            _mercadoriaAdapter = mercadoriaAdapter;

        }

        public List<int> ObterIdDeTodasAsMercadorias()
        {
            return _mercadoriaRepository.ObterIdDeTodasAsMercadorias();
        }

        public List<MercadoriaDTO> ObterTodasAsMercadorias()
        {
            var entity = _mercadoriaRepository.ObterTodasAsMercadorias();
            var toDto = _mercadoriaAdapter.ToMercadoriaDTO(entity);
            return toDto;

        }

        public async Task<bool> RegistrarMercadoria(MercadoriaDTO mercadoriaDTO)
        {
            var toEnity = _mercadoriaAdapter.ToMercadoriaEntity(mercadoriaDTO);
            await _mercadoriaRepository.CadastrarMercadoria(toEnity);
            return true;
        }
    }
}
