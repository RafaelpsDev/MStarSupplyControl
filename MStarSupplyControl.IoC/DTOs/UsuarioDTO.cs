using System.ComponentModel.DataAnnotations;

namespace MStarSupplyControl.IoC.DTOs
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "Usuário inválido.")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Senha inválida.")]
        public string Senha { get; set; }
    }
}

