using System.ComponentModel.DataAnnotations;

namespace Dashboard.Domain.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
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
