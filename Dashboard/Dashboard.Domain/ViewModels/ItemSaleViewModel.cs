using System.ComponentModel.DataAnnotations;

namespace Domain.Models.ViewModels
{
    public class ItemSaleViewModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnityValue { get; set; }
        [Required]
        public double TotalValue { get; set; }

        public int SaleId { get; set; }
    }
}
