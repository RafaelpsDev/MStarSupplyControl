
namespace MStarSupplyControl.Domain.Entities
{
    public class RelatorioEntity
    {
        public int IdMercadoria { get; set; }
        public string Mercadoria { get; set; }
        public string Fabricante { get; set; }
        public string Tipo { get; set; }
        public string Mes { get; set; }
        public int TotalEntrada { get; set; }
        public int TotalSaida { get; set; }

    }
}
