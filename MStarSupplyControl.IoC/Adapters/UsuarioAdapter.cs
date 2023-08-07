using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.IoC.DTOs;
using MStarSupplyControl.IoC.Interfaces;

namespace MStarSupplyControl.IoC.Adapters
{
    public class UsuarioAdapter : IUsuarioAdapter
    {
        public UsuarioEntity ToUsuarioEntity(UsuarioDTO usuarioDTO)
        {
            return new UsuarioEntity
            {
                Usuario = usuarioDTO.Usuario,
                Senha = usuarioDTO.Senha
            };
        }
    }
}
