using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.IoC.DTOs;

namespace MStarSupplyControl.IoC.Interfaces
{
    public interface IMercadoriaAdapter
    {
        public MercadoriaEntity ToMercadoriaEntity(MercadoriaDTO mercadoriaDTO);
        public List<MercadoriaDTO> ToMercadoriaDTO(List<MercadoriaEntity> mercadoriaEntity);
    }
}
