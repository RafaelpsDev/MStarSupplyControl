using Dapper;
using MStarSupplyControl.Domain.Entities;
using MStarSupplyControl.Infrastructure.Interfaces;
using System.Data;

namespace MStarSupplyControl.Infrastructure.DynamicParametersRepository
{
    
    public class GerenciamentoParameters : IGerenciamentoParameters
    {
        private readonly DynamicParameters p;
        public GerenciamentoParameters()
        {
            p = new DynamicParameters();   
        }
        public DynamicParameters ParametrosEntrada(EntradaEntity entradaEntity)
        {
            p.Add("@P_ID_MERCADORIA", entradaEntity.IdMercadoria, DbType.Int32);
            p.Add("@P_QUANTIDADE", entradaEntity.Quantidade, DbType.Int32);
            p.Add("@P_DATA_ENTRADA", entradaEntity.DataDeEntrada, DbType.DateTime);
            p.Add("@P_HORA_ENTRADA", entradaEntity.HoraDeEntrada, DbType.Time);
            p.Add("@P_LOCAL", entradaEntity.Local, DbType.String);
            return p;
        }

        public DynamicParameters ParametrosQuantidade(string mercadoria)
        {
            p.Add("@Mercadoria", mercadoria, DbType.String);
            return p;
        }

        public DynamicParameters ParametrosSaida(SaidaEntity saidaEntity)
        {
            p.Add("@P_ID_MERCADORIA", saidaEntity.IdMercadoria, DbType.Int32);
            p.Add("@P_QUANTIDADE", saidaEntity.Quantidade, DbType.Int32);
            p.Add("@P_DATA_SAIDA", saidaEntity.DataDeSaida, DbType.DateTime);
            p.Add("@P_HORA_SAIDA", saidaEntity.HoraDeSaida, DbType.Time); 
            p.Add("@P_LOCAL", saidaEntity.Local, DbType.String);
            return p;
        }
    }
}
