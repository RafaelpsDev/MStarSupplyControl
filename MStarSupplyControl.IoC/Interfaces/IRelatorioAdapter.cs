using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.IoC.DTOs;

namespace MStarSupplyControl.IoC.Interfaces
{
    public interface IRelatorioAdapter
    {
        public List<ResponseRelatorioMensalDTO> ToResponseRelatorioMensalDTO(List<RelatorioEntity> relatorioEntity);

    }
}
