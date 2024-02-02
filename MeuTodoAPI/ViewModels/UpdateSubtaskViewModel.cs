using System.ComponentModel.DataAnnotations;

namespace MeuTodoAPI.ViewModels
{
    public class UpdateSubtaskViewModel
    {
        public string Description { get; set; }
        [Required]
        public bool Done { get; set; }
    }
}
