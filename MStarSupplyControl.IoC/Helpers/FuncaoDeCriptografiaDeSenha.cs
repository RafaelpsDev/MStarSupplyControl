using System.Security.Cryptography;
using System.Text;

namespace MStarSupplyControl.IoC.Helpers
{
    public class FuncaoDeCriptografiaDeSenha
    {
        public static string CriptografarSenha(string senha)
        {
            byte[] bytesSenha = Encoding.UTF8.GetBytes(senha);
            byte[] hashSenha = SHA256.HashData(bytesSenha);
            return Convert.ToBase64String(hashSenha);
        }
    }
}
