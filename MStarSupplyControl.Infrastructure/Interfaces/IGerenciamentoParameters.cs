using Dapper;
using MStarSupplyControl.Domain.Entities;

namespace MStarSupplyControl.Infrastructure.Interfaces
{
    public interface IGerenciamentoParameters
    {
        public DynamicParameters ParametrosEntrada(EntradaEntity entradaEntity);
        public DynamicParameters ParametrosSaida(SaidaEntity saidaEntity);
        public DynamicParameters ParametrosQuantidade(string mercadoria);
    }
}
