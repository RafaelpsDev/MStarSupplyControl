using Dapper;
using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.Infrastructure.Context.Scripts;
using MStarSupplyControl.Infrastructure.Interfaces;
using System.Data.SqlClient;

namespace MStarSupplyControl.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IUsuarioParameters _usuarioParameters;
        private readonly IConexao _conexao;
        public UsuarioRepository(IUsuarioParameters usuarioParameters, IConexao conexao)
        {
            _usuarioParameters = usuarioParameters;
            _conexao = conexao;
        }
        public async Task<UsuarioEntity> ObterUsuario(UsuarioEntity usuarioEntity)
        {
            var p = _usuarioParameters.ParametrosUsuario(usuarioEntity);
            using var cn = new SqlConnection(_conexao.StringConexao);
            await cn.OpenAsync();
            var retorno = await cn.QueryFirstOrDefaultAsync<UsuarioEntity>(UsuarioScript.ObterUsuario, p);
            return retorno;
        }
    }
}
