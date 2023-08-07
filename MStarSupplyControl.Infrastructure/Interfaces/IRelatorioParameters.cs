using Dapper;

namespace MStarSupplyControl.Infrastructure.Interfaces
{
    public interface IRelatorioParameters
    {
        public DynamicParameters ParametrosRelatorio(string Mercadoria);
    }
}
