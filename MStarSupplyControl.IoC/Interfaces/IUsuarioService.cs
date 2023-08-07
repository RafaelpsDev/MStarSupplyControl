using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.IoC.DTOs;

namespace MStarSupplyControl.IoC.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioEntity> ObterUsuario(UsuarioDTO usuarioDTO);
    }
}
