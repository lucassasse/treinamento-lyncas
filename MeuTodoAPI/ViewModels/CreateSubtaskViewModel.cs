using System.ComponentModel.DataAnnotations;

namespace MeuTodoAPI.ViewModels
{
    public class CreateSubtaskViewModel
    {
        [Required]
        public string Description { get; set; }
    }
}
