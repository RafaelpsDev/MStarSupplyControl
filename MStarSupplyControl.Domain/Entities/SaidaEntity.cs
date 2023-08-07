
namespace MStarSupplyControl.Domain.Entities
{
    public class SaidaEntity
    {
        public int IdMercadoria { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataDeSaida { get; set; }
        public TimeSpan HoraDeSaida { get; set; }
        public string Local { get; set; }
    }
}
