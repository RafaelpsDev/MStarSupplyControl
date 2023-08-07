using System.ComponentModel.DataAnnotations;

namespace MStarSupplyControl.IoC.DTOs
{
    public class GerenciamentoEntradaDTO
    {
        [Required(ErrorMessage = "Por favor, selecione uma mercadoria")]
        public string Mercadoria { get; set; }
        [Required(ErrorMessage = "Por favor, informe a quantidade")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Por favor, informe a data")]
        public DateTime DataDeEntrada { get; set; }
        [Required(ErrorMessage = "Por favor, informe a hora")]
        public TimeSpan HoraDeEntrada { get; set; }
        [Required(ErrorMessage = "Por favor, informe o local de entrada")]
        public string Local { get; set; }

    }
}
