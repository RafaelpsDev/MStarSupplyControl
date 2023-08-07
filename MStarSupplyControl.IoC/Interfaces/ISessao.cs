using MStarSupplyControl.Domain.Entities;

namespace MStarSupplyControl.IoC.Interfaces
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioEntity usuarioEntity);
        void RemoverSessaoDoUsuario();
        UsuarioEntity BuscarSessaoDoUsuario();
    }
}
