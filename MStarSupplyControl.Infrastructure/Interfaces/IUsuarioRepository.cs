using MStarSupplyControl.Domain.Entities;

namespace MStarSupplyControl.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioEntity> ObterUsuario(UsuarioEntity usuarioEntity);
    }
}
