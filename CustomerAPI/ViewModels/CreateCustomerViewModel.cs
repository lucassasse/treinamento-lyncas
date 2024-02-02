using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.ViewModels
{
    public class CreateCustomerViewModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public string Cpf { get; set; }
    }
}
