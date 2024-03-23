using System.ComponentModel.DataAnnotations;

namespace Dashboard.Domain.Dtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "O campo é email é obrigatório."), EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo é senha é obrigatório.")]
        public string Password { get; set; }
    }
}
