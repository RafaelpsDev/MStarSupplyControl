using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.IoC.DTOs;
using MStarSupplyControl.IoC.Interfaces;

namespace MStarSupplyControl.IoC.Adapters
{
    public class RelatorioAdapter : IRelatorioAdapter
    {
        public List<ResponseRelatorioMensalDTO> ToResponseRelatorioMensalDTO(List<RelatorioEntity> relatorioEntity)
        {
            List<ResponseRelatorioMensalDTO> responseRelatorioMensal = new();
            foreach (var entity in relatorioEntity)
            {
                responseRelatorioMensal.Add(
                    new ResponseRelatorioMensalDTO
                    {
                        IdMercadoria = entity.IdMercadoria,
                        Mercadoria = entity.Mercadoria,
                        Fabricante = entity.Fabricante,
                        Tipo = entity.Tipo,
                        Mes = entity.Mes,
                        TotalEntrada = entity.TotalEntrada,
                        TotalSaida = entity.TotalSaida
                    });
            }
            return responseRelatorioMensal;
        }
    }
}
