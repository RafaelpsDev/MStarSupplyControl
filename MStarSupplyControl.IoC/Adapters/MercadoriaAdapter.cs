using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.IoC.DTOs;
using MStarSupplyControl.IoC.Interfaces;

namespace MStarSupplyControl.IoC.Adapters
{
    public class MercadoriaAdapter : IMercadoriaAdapter
    {
        public List<MercadoriaDTO> ToMercadoriaDTO(List<MercadoriaEntity> mercadoriaEntity)
        {
            List<MercadoriaDTO> mercadoriaDTO = new();
            foreach (var entity in mercadoriaEntity)
            {
                mercadoriaDTO.Add(
                    new MercadoriaDTO
                    {
                        Nome = entity.Nome,
                        Fabricante = entity.Fabricante,
                        Tipo = entity.Tipo,
                        Quantidade = entity.Quantidade
                    });
            }
            return mercadoriaDTO;
        }

        public MercadoriaEntity ToMercadoriaEntity(MercadoriaDTO mercadoriaDTO)
        {
            return new MercadoriaEntity
            {
                Nome = mercadoriaDTO.Nome,
                Fabricante = mercadoriaDTO.Fabricante,
                Tipo = mercadoriaDTO.Tipo,
                Quantidade = mercadoriaDTO.Quantidade,
                Descricao = mercadoriaDTO.Descricao
            };
        }
    }
}
