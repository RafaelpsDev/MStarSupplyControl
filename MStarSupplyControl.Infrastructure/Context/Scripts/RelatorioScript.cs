
namespace MStarSupplyControl.Infrastructure.Context.Scripts
{
    public class RelatorioScript
    {
        public static string ObterTotalRelatorioPdf
        {
            get
            {
                return @"SELECT 
                             IdMercadoria
                            ,Mercadoria
                            ,Fabricante
                            ,Tipo
                            ,dbo.FN_MES_TEXTO(Mes) as Mes
                            ,TotalEntrada
                            ,TotalSaida
                            FROM VW_RELATORIO_ENTRADA_E_SAIDA";
            }
        }

        public static string ObterTotalRelatorioGrafico
        {
            get
            {
                return @"SELECT 
                             dbo.FN_MES_TEXTO(Mes) as Mes
                            ,TotalEntrada
                            ,TotalSaida
                            FROM VW_RELATORIO_ENTRADA_E_SAIDA WHERE Mercadoria = @Mercadoria";
            }
        }
    }
}
