using System.ComponentModel.DataAnnotations;

namespace Dashboard.Domain.Dtos
{
    public class UserDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
