using Dapper;
using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.Infrastructure.Context.Scripts;
using MStarSupplyControl.Infrastructure.Interfaces;
using System.Data.SqlClient;

namespace MStarSupplyControl.Infrastructure.Repository
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly IConexao _conexao;
        private readonly IRelatorioParameters _relatorioParameters;
        public RelatorioRepository(IConexao conexao, IRelatorioParameters relatorioParameters)
        {
            _conexao = conexao;
            _relatorioParameters = relatorioParameters;

        }
        public List<RelatorioEntity> ObterTotalParaRelatorioGrafico(string Mercadoria)
        {
            var p = _relatorioParameters.ParametrosRelatorio(Mercadoria);
            using var cn = new SqlConnection(_conexao.StringConexao);
            cn.Open();
            var totalEntrada = cn.Query<RelatorioEntity>(RelatorioScript.ObterTotalRelatorioGrafico, p);
            return totalEntrada.ToList();
        }

        public List<RelatorioEntity> ObterTotalParaRelatorioPdf()
        {
            using var cn = new SqlConnection(_conexao.StringConexao);
            cn.Open();
            var totalEntrada = cn.Query<RelatorioEntity>(RelatorioScript.ObterTotalRelatorioPdf);
            return totalEntrada.ToList();
        }
    }
}
