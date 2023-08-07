using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.Infrastructure.Interfaces;
using MStarSupplyControl.IoC.DTOs;
using MStarSupplyControl.IoC.Helpers;
using MStarSupplyControl.IoC.Interfaces;

namespace MStarSupplyControl.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioAdapter _uisarioAdapter;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioAdapter usuarioAdapter, IUsuarioRepository usuarioRepository)
        {
            _uisarioAdapter = usuarioAdapter;
            _usuarioRepository = usuarioRepository;
        }
        public async Task<UsuarioEntity> ObterUsuario(UsuarioDTO usuarioDTO)
        {
            usuarioDTO.Senha = FuncaoDeCriptografiaDeSenha.CriptografarSenha(usuarioDTO.Senha);
            var toEntity = _uisarioAdapter.ToUsuarioEntity(usuarioDTO);
            var usuario = await _usuarioRepository.ObterUsuario(toEntity) ?? throw new NullReferenceException("O Usuário informado não existe");

            if (usuario.Senha != usuarioDTO.Senha)
            {
                throw new ArgumentException("A senha informada é incorreta");
            }            
            return await _usuarioRepository.ObterUsuario(toEntity);
        }
    }
}
