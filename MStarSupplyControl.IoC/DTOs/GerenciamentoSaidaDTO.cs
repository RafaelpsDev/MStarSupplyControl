using System.ComponentModel.DataAnnotations;

namespace MStarSupplyControl.IoC.DTOs
{
    public class GerenciamentoSaidaDTO
    {
        [Required(ErrorMessage = "Por favor, selecione uma mercadoria")]
        public string Mercadoria { get; set; }
        [Required(ErrorMessage = "Por favor, informe a quantidade")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Por favor, informe a data")]
        public DateTime DataDeSaida { get; set; }
        [Required(ErrorMessage = "Por favor, informe a hora")]
        public TimeSpan HoraDeSaida { get; set; }
        [Required(ErrorMessage = "Por favor, informe o local de saída")]
        public string Local { get; set; }
    }
}
