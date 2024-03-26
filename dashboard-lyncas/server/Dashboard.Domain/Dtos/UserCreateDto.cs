using System.ComponentModel.DataAnnotations;

namespace Dashboard.Domain.Dtos
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "O campo é email é obrigatório."), EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Senhas não coincidem.")]
        public string ConfirmPassword { get; set; }
    }
}
