using System.ComponentModel.DataAnnotations;

namespace Dashboard.Domain.ViewModels
{
    public class ItemSaleDto
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
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
