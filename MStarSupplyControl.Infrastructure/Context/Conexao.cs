using Microsoft.Extensions.Configuration;
using MStarSupplyControl.Infrastructure.Interfaces;

namespace MStarSupplyControl.Infrastructure.Context
{
    public class Conexao : IConexao
    {
        private readonly IConfiguration _configuration;
        public Conexao(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string StringConexao => _configuration.GetConnectionString("DefaultConnection");        
    }
}
