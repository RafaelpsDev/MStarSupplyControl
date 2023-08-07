using Dapper;
using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.Infrastructure.Interfaces;
using System.Data;

namespace MStarSupplyControl.Infrastructure.DynamicParametersRepository
{
    public class UsuarioParameters : IUsuarioParameters
    {
        private readonly DynamicParameters p;
        public UsuarioParameters()
        {
            p = new DynamicParameters();
        }
        public DynamicParameters ParametrosUsuario(UsuarioEntity usuarioEntity)
        {
            p.Add("@Usuario", usuarioEntity.Usuario, DbType.String);
            p.Add("@Senha", usuarioEntity.Senha, DbType.String);
            return p;

        }
    }
}
