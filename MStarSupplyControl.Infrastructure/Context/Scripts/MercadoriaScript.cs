
namespace MStarSupplyControl.Infrastructure.Context.Scripts
{
    public class MercadoriaScript
    {
        public static string CadastrarMercadoria { 
            get
            {
                return @"INSERT INTO TB_MERCADORIAS VALUES (@Nome, @Fabricante, @Tipo, @Descricao)";
            } 
        }
        public static string ObterNomeMercadoria
        {
            get
            {
                return @"SELECT NOME AS Mercadoria FROM TB_MERCADORIAS";
            }
        }
        public static string ObterIdDaMercadoriaPeloNome
        {
            get
            {
                return @"SELECT ID FROM TB_MERCADORIAS WHERE NOME = @Mercadoria";
            }
        }

        public static string ObterIdDeTodasMercadorias
        {
            get
            {
                return @"SELECT ID FROM TB_MERCADORIAS";
            }
        }
        public static string ObterTodasAsMercadorias
        {
            get
            {
                return @"SELECT DISTINCT
                             M.NOME AS Nome
                            ,M.TIPO AS Tipo
                            ,M.FABRICANTE AS Fabricante
                            ,E.QUANTIDADE AS Quantidade
                            FROM TB_MERCADORIAS M
                            LEFT JOIN TB_ESTOQUE E
                            ON M.ID = E.ID_MERCADORIA";
            }
        }
    }
}
