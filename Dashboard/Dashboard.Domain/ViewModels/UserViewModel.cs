using System.ComponentModel.DataAnnotations;

namespace Domain.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
