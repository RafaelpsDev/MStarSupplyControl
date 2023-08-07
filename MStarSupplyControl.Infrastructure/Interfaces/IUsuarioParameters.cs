using Dapper;
using MStarSupplyControl.Domain.Entities;

namespace MStarSupplyControl.Infrastructure.Interfaces
{
    public interface IUsuarioParameters
    {
        public DynamicParameters ParametrosUsuario(UsuarioEntity usuarioEntity);
    }
}
