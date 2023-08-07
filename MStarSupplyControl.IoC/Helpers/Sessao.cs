using Microsoft.AspNetCore.Http;
using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.IoC.Interfaces;
using Newtonsoft.Json;

namespace MStarSupplyControl.IoC.Helpers
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;
        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public UsuarioEntity BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("SessaoUsuarioLogado");
            if (String.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioEntity>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(UsuarioEntity usuarioEntity)
        {
            string valor = JsonConvert.SerializeObject(usuarioEntity);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("SessaoUsuarioLogado");
        }
    }
}
