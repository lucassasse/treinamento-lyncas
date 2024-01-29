using System.ComponentModel.DataAnnotations;

namespace MeuTodoAPI.ViewModels
{
    public class CreateTodoViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
