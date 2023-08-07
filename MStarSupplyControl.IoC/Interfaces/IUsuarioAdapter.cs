using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.IoC.DTOs;

namespace MStarSupplyControl.IoC.Interfaces
{
    public interface IUsuarioAdapter
    {
        public UsuarioEntity ToUsuarioEntity(UsuarioDTO usuarioDTO);
    }
}
