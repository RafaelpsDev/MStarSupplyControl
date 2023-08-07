using Dapper;
using MStarSupplyControl.Domain.Entities;

namespace MStarSupplyControl.Infrastructure.Interfaces
{
    public interface IMercadoriaParameters
    {
        public DynamicParameters ParametrosMercadoria(MercadoriaEntity mercadoriaEntity);

        public DynamicParameters ParametrosObterIdMercadoria(string Mercadoria);
    }
}
