using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MStarSupplyControl.Application.Services
{
    public class EventosDePaginaService : PdfPageEventHelper
    {
        private PdfContentByte wdc;
        private BaseFont FonteBaseRodape { get; set; }
        private Font FonteRodape { get; set; }
        public int TotalPaginas { get; set; }

        public EventosDePaginaService(int totalPaginas)
        {
            FonteBaseRodape = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            FonteRodape = new Font(FonteBaseRodape, 8f, Font.NORMAL, BaseColor.Black);
            TotalPaginas = totalPaginas;
        }
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
            this.wdc = writer.DirectContent;
        }
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            AdicionarMomentoGeracaoRelatorio(document, GetWdc());
            AdicionarNumeroDasPaginas(writer, document);
        }

        private PdfContentByte GetWdc()
        {
            return wdc;
        }

        //Metodo de geração de momento do relatório encapsulado por organização para utilizar no método acima.
        private void AdicionarMomentoGeracaoRelatorio(Document document, PdfContentByte wdc)
        {
            var textoMomentoGeracao = $"Gerado em {DateTime.Now.ToShortDateString()} às " +
                $"{DateTime.Now.ToShortTimeString()}";
            wdc.BeginText();
            wdc.SetFontAndSize(FonteRodape.BaseFont, FonteRodape.Size);
            wdc.SetTextMatrix(document.LeftMargin, document.BottomMargin * 0.75f);
            wdc.ShowText(textoMomentoGeracao);
            wdc.EndText();
        }

        private void AdicionarNumeroDasPaginas(PdfWriter writer, Document document)
        {
            int paginaAtual = writer.PageNumber;
            var textoPaginacao = $"Página {paginaAtual} de {TotalPaginas}";

            float larguraTextoPaginacao =
                FonteBaseRodape.GetWidthPoint(textoPaginacao, FonteRodape.Size);

            var tamanhoPagina = document.PageSize;
            wdc.BeginText();
            wdc.SetFontAndSize(FonteRodape.BaseFont, FonteRodape.Size);
            wdc.SetTextMatrix(tamanhoPagina.Width - document.RightMargin - larguraTextoPaginacao, document.BottomMargin * 0.75f);
            wdc.ShowText(textoPaginacao);
            wdc.EndText();

        }
    }
}
