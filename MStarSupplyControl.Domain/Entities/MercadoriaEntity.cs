
namespace MStarSupplyControl.Domain.Entities
{
    public class MercadoriaEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public int Quantidade { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
    }
}
