
namespace MStarSupplyControl.Domain.Entities
{
    public class EntradaEntity
    {
        public int IdMercadoria{ get; set; }
        public int Quantidade { get; set; }
        public DateTime DataDeEntrada { get; set; }        
        public TimeSpan HoraDeEntrada { get; set; }
        public string Local { get; set; }
    }
}
