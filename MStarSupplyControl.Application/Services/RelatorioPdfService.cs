using iTextSharp.text.pdf;
using iTextSharp.text;
using MStarSupplyControl.IoC.Interfaces;

namespace MStarSupplyControl.Application.Services
{
    public class RelatorioPdfService : IRelatorioPdfService
    {
        private readonly IRelatorioService _relatorioService;
        public RelatorioPdfService(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;}
        public void GerarRelatorioMensalPdf()
        {
            var dadosRelatorio = _relatorioService.ObterTotalParaRelatorioPdf();

            // Caminho onde o arquivo PDF será salvo no servidor (ajuste de acordo com sua necessidade)
            var caminhoArquivoPDF = $"C:/Users/notec/OneDrive/Área de Trabalho/MStarSupplyControl/RelatoriosPdf/RelatorioMensal_{DateTime.Now:yyyy-MM-dd}.pdf";

            int totalPaginas = 1;
            int totallinhas = dadosRelatorio.Count;
            if (totallinhas > 24)
                _ = (int)Math.Ceiling((totalPaginas - 24) / 29F);

            // Tamanho padrão do A4 em pontos (1 polegada = 72 pontos)
            const float A4Width = 595f;
            const float A4Height = 842f;

            // Defina a margem como preferir
            const float marginLeft = 15f;
            const float marginRight = 15f;
            const float marginTop = 15f;
            const float marginBottom = 20f;

            // Defina a orientação paisagem
            var pageSize = new Rectangle(A4Height, A4Width);

            // Crie o documento usando o tamanho da página e as margens
            var pdf = new Document(pageSize, marginLeft, marginRight, marginTop, marginBottom);

                                    
            //Cria o arquivo sobrepondo o existente com o mesmo nome.
            var arquivo = new FileStream(caminhoArquivoPDF, FileMode.Create);

            //Associa pdf ao arquivo.
            var writer = PdfWriter.GetInstance(pdf, arquivo);
            writer.PageEvent = new EventosDePaginaService(totalPaginas);
            //Inicalizando o pdf
            pdf.Open();

            var fonte = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            var fonteParagrafo = new Font(fonte, 18, Font.BOLDITALIC, BaseColor.Black);

            //Cria o titulo
            var titulo = new Paragraph("Relatório de entrada e saída de mercadorias", fonteParagrafo)
            {
                //Alinha a esquerda
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 4
            };
            //Adiciona o titulo ao PDF
            pdf.Add(titulo);

            var caminhoImagem = "C:/Users/notec/OneDrive/Área de Trabalho/MStarSupplyControl/ImagemParaPdf/LogoMStar.png";
            if (File.Exists(caminhoImagem))
            {
                Image logoParaPdf = Image.GetInstance(caminhoImagem);
                //posiciona e redimenciona a imagem
                float razaoAlturaLargura = logoParaPdf.Width / logoParaPdf.Height;
                float alturaLogo = 45;
                float larguraLogo = alturaLogo * razaoAlturaLargura;
                logoParaPdf.ScaleToFit(larguraLogo, alturaLogo);

                var margemEsquerda = pdf.PageSize.Width - pdf.RightMargin - larguraLogo;
                var margemTopo = pdf.PageSize.Height - pdf.TopMargin - 54;
                logoParaPdf.SetAbsolutePosition(margemEsquerda, margemTopo);
                writer.DirectContent.AddImage(logoParaPdf, false);
            }

            //adiciona a tabela de dados
            var tabela = new PdfPTable(7);
            float[] larguraDasColunas = { 0.2f, 2f, 1f, 1f,  1f, 1.1f, 1f };
            tabela.SetWidths(larguraDasColunas);

            //sem borda
            tabela.DefaultCell.BorderWidth = 0;
            //vai ocupar 100% da largura disponivel
            tabela.WidthPercentage = 100;

            //Adiciona células de títulos das colunas
            CelulaTextoService.CriarCelulaTexto(tabela, "ID", PdfCell.ALIGN_CENTER, true);
            CelulaTextoService.CriarCelulaTexto(tabela, "Mercadoria", PdfCell.ALIGN_CENTER, true);
            CelulaTextoService.CriarCelulaTexto(tabela, "Fabricante", PdfCell.ALIGN_CENTER, true);
            CelulaTextoService.CriarCelulaTexto(tabela, "Tipo", PdfCell.ALIGN_CENTER, true);
            CelulaTextoService.CriarCelulaTexto(tabela, "Mês", PdfCell.ALIGN_CENTER, true);
            CelulaTextoService.CriarCelulaTexto(tabela, "Entradas", PdfCell.ALIGN_CENTER, true);
            CelulaTextoService.CriarCelulaTexto(tabela, "Saídas", PdfCell.ALIGN_CENTER, true);

            foreach (var dados in dadosRelatorio)
            {
                CelulaTextoService.CriarCelulaTexto(tabela, dados.IdMercadoria.ToString("D2"), PdfCell.ALIGN_CENTER, true);
                CelulaTextoService.CriarCelulaTexto(tabela, dados.Mercadoria, PdfCell.ALIGN_CENTER, true);
                CelulaTextoService.CriarCelulaTexto(tabela, dados.Fabricante, PdfCell.ALIGN_CENTER, true);
                CelulaTextoService.CriarCelulaTexto(tabela, dados.Tipo, PdfCell.ALIGN_CENTER, true);
                CelulaTextoService.CriarCelulaTexto(tabela, dados.Mes, PdfCell.ALIGN_CENTER, true);
                CelulaTextoService.CriarCelulaTexto(tabela, dados.TotalEntrada.ToString("D2"), PdfCell.ALIGN_CENTER, true);
                CelulaTextoService.CriarCelulaTexto(tabela, dados.TotalSaida.ToString("D2"), PdfCell.ALIGN_CENTER, true);

            }
            pdf.Add(tabela);

            pdf.Close();
            arquivo.Close();
        }
    }
}
