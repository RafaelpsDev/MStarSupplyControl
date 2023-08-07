
namespace MStarSupplyControl.Infrastructure.Context.Scripts
{
    public class UsuarioScript
    {
        public static string ObterUsuario
        {
            get
            {
                return @"SELECT * FROM TB_USUARIOS WHERE USUARIO = @Usuario AND SENHA = @Senha";
            }
        }
    }
}
