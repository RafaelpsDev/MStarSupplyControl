using Dapper;
using MStarSupplyControl.Infrastructure.Interfaces;
using System.Data;

namespace MStarSupplyControl.Infrastructure.DynamicParametersRepository
{
    public class RelatorioParameters : IRelatorioParameters
    {
        private readonly DynamicParameters p;
        public RelatorioParameters()
        {
            p = new DynamicParameters();
        }
        public DynamicParameters ParametrosRelatorio(string Mercadoria)
        {
            p.Add("@Mercadoria", Mercadoria, DbType.String);
            return p;
        }
    }
}
