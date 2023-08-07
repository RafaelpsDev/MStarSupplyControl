
namespace MStarSupplyControl.Infrastructure.Context.Scripts
{
    public class GerenciamentoScript
    {
        public static string ObterQuantidade
        {
            get
            {
                return @"        SELECT
                                    E.QUANTIDADE
                                    FROM TB_ESTOQUE E
                                    INNER JOIN TB_MERCADORIAS M
                                    ON E.ID_MERCADORIA = M.ID
                                    WHERE M.NOME = NOME";
            }
        }




    }
}
