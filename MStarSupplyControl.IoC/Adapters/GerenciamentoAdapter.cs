using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.IoC.DTOs;
using MStarSupplyControl.IoC.Interfaces;

namespace MStarSupplyControl.IoC.Adapters
{
    public class GerenciamentoAdapter : IGerenciamentoAdapter
    {
        public EntradaEntity ToGerenciamentoEntityEntrada(GerenciamentoEntradaDTO gerenciamentoEntradaDTO)
        {
            return new EntradaEntity
            {
                Quantidade = gerenciamentoEntradaDTO.Quantidade,
                HoraDeEntrada = gerenciamentoEntradaDTO.HoraDeEntrada,
                Local = gerenciamentoEntradaDTO.Local
            };
        }

        public SaidaEntity ToGerenciamentoEntitySaida(GerenciamentoSaidaDTO gerenciamentoSaidaDTO)
        {
            return new SaidaEntity
            {
                Quantidade = gerenciamentoSaidaDTO.Quantidade,
                HoraDeSaida = gerenciamentoSaidaDTO.HoraDeSaida,
                Local = gerenciamentoSaidaDTO.Local
            };
        }
    }
}
