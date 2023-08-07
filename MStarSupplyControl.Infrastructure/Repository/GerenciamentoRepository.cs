using Dapper;
using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.Infrastructure.Context.Scripts;
using MStarSupplyControl.Infrastructure.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace MStarSupplyControl.Infrastructure.Repository
{
    public class GerenciamentoRepository : IGerenciamentoRepository
    {
        private readonly IConexao _conexao;
        private readonly IGerenciamentoParameters _estoqueParameters;
        public GerenciamentoRepository(IConexao conexao, IGerenciamentoParameters estoqueParameters)
        {
            _conexao = conexao;
            _estoqueParameters = estoqueParameters;

        }

        public async Task<int> ObterQuantidade(string mercadoria)
        {
            using var cn = new SqlConnection(_conexao.StringConexao);
            await cn.OpenAsync();
            var retorno = await cn.QueryFirstOrDefaultAsync<int>(GerenciamentoScript.ObterQuantidade, new {NOME = mercadoria});
            return retorno;
        }

        public async Task<bool> RegistrarEntrada(EntradaEntity entradaEntity)
        {
            DynamicParameters p = _estoqueParameters.ParametrosEntrada(entradaEntity);
            using var cn = new SqlConnection(_conexao.StringConexao);
            await cn.OpenAsync();
            await cn.ExecuteAsync("PR_REGISTRA_ENTRADA_GERA_LOG", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public async Task<bool> RegistrarSaida(SaidaEntity saidaEntity)
        {
            DynamicParameters p = _estoqueParameters.ParametrosSaida(saidaEntity);
            using var cn = new SqlConnection(_conexao.StringConexao);
            await cn.OpenAsync();
            await cn.ExecuteAsync("PR_REGISTRA_SAIDA_GERA_LOG", p, commandType: CommandType.StoredProcedure);
            return true;
        }       
    }
}
