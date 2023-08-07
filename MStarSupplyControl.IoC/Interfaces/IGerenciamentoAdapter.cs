using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.IoC.DTOs;

namespace MStarSupplyControl.IoC.Interfaces
{
    public interface IGerenciamentoAdapter
    {
        public EntradaEntity ToGerenciamentoEntityEntrada(GerenciamentoEntradaDTO gerenciamentoEntradaDTO);
        public SaidaEntity ToGerenciamentoEntitySaida(GerenciamentoSaidaDTO gerenciamentoSaida);
    }
}
