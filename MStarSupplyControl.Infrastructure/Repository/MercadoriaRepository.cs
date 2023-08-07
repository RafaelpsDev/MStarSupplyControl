using Dapper;
using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.Infrastructure.Context.Scripts;
using MStarSupplyControl.Infrastructure.Interfaces;
using System.Data.SqlClient;

namespace MStarSupplyControl.Infrastructure.Repository
{
    public class MercadoriaRepository : IMercadoriaRepository
    {
        private readonly IConexao _conexao;
        private readonly IMercadoriaParameters _mercadoriaParameters;
        public MercadoriaRepository(IConexao conexao, IMercadoriaParameters mercadoriaParameters)
        {
            _conexao = conexao;
            _mercadoriaParameters = mercadoriaParameters;
        }
        public async Task<bool> CadastrarMercadoria(MercadoriaEntity mercadoriaEntity)
        {
                var p = _mercadoriaParameters.ParametrosMercadoria(mercadoriaEntity);
                using var cn = new SqlConnection(_conexao.StringConexao);
                await cn.OpenAsync();
                await cn.ExecuteAsync(MercadoriaScript.CadastrarMercadoria, p);
                return true;            
        }

        public async Task<int> ObterIdDaMercadoriasPeloNome(string Mercadoria)
        {
            var p = _mercadoriaParameters.ParametrosObterIdMercadoria(Mercadoria);
            using var cn = new SqlConnection(_conexao.StringConexao);
            await cn.OpenAsync();
            var retorno = await cn.QueryFirstAsync<int>(MercadoriaScript.ObterIdDaMercadoriaPeloNome, p);
            return retorno;
        }
        public List<int> ObterIdDeTodasAsMercadorias()
        {
            using var cn = new SqlConnection(_conexao.StringConexao);
            cn.Open();
            var retorno = cn.Query<int>(MercadoriaScript.ObterIdDeTodasMercadorias);
            return retorno.ToList();
        }

        public List<string> ObterNomeDeTodasMercadorias()
        {
            using var cn = new SqlConnection(_conexao.StringConexao);
            cn.Open();
            var retorno = cn.Query<string>(MercadoriaScript.ObterNomeMercadoria);
            return retorno.ToList();
        }

        public List<MercadoriaEntity> ObterTodasAsMercadorias()
        {
            using var cn = new SqlConnection(_conexao.StringConexao);
            cn.Open();
            var retorno = cn.Query<MercadoriaEntity>(MercadoriaScript.ObterTodasAsMercadorias);
            return retorno.ToList();
        }
    }
}
