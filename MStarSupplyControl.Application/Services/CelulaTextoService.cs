using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MStarSupplyControl.Application.Services
{
    public class CelulaTextoService
    {
        public static PdfPTable CriarCelulaTexto(
            PdfPTable tabela, 
            string texto, 
            int alinhamentoHorz = PdfPCell.ALIGN_LEFT, 
            bool negrito = false, 
            bool italico = false,
            int tamanhoFonte = 12,
            int alturaCelula = 25)
        {
            int estilo = Font.NORMAL;
            if (negrito && italico)
            {
                estilo = Font.BOLDITALIC;
            }
            else if (negrito)
            {
                estilo = Font.BOLD;
            }
            else if (italico)
            {
                estilo = Font.ITALIC;
            }

            //esse trecho faz o zebrado do relatório
            var bgColor = BaseColor.White;
            if (tabela.Rows.Count % 2 == 1)
            {
                bgColor = new BaseColor(0.90F, 0.90F, 0.90F);
            }
                //Adiciona células de títulos das colunas
            var fonte = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            var fonteCelula = new Font(fonte, tamanhoFonte, estilo, BaseColor.Black);
            var celula = new PdfPCell(new Phrase(texto, fonteCelula))
            {
                HorizontalAlignment = alinhamentoHorz,
                VerticalAlignment = PdfPCell.ALIGN_MIDDLE,
                Border = 0,
                BorderWidthBottom = 1,
                FixedHeight = alturaCelula,
                PaddingBottom = 5,
                BackgroundColor = bgColor
            };
            tabela.AddCell(celula);
            return tabela;
        }
    }
}
