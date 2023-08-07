using Dapper;
using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.Infrastructure.Interfaces;
using System.Data;

namespace MStarSupplyControl.Infrastructure.DynamicParametersRepository
{
    public class MercadoriaParameters : IMercadoriaParameters
    {
        private readonly DynamicParameters p;
        public MercadoriaParameters()
        {
            p = new DynamicParameters();
        }
        public DynamicParameters ParametrosMercadoria(MercadoriaEntity mercadoriaEntity)
        {
            p.Add("@Nome", mercadoriaEntity.Nome, DbType.String);
            p.Add("@Fabricante", mercadoriaEntity.Fabricante, DbType.String);
            p.Add("@Tipo", mercadoriaEntity.Tipo, DbType.String);
            p.Add("@Descricao", mercadoriaEntity.Descricao, DbType.String);
            return p;
        }

        public DynamicParameters ParametrosObterIdMercadoria(string Mercadoria)
        {
            p.Add("@Mercadoria", Mercadoria, DbType.String);
            return p;
        }
    }
}
