using System.ComponentModel.DataAnnotations;

namespace Dashboard.Domain.Dtos
{
    public class ItemSaleDto
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnityValue { get; set; }
        [Required]
        public double TotalValue { get; set; }
    }
}
