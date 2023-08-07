using System.ComponentModel.DataAnnotations;

namespace MStarSupplyControl.IoC.DTOs
{
    public class MercadoriaDTO
    {
        [Required(ErrorMessage = "Por favor, selecione uma mercadoria")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor, informe o campo Fabricante")]
        public string Fabricante { get; set; }
        [Required(ErrorMessage = "Por favor, informe o campo Tipo")]
        public string Tipo { get; set; }
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Por favor, informe a descrição")]
        public string Descricao { get; set; }
    }
}
