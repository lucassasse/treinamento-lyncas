using System.ComponentModel.DataAnnotations;

namespace Domain.Models.ViewModels
{
    public class SaleViewModel
    {
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        public DateTime BillingDate { get; set; }
        [Required]
        public double SaleTotalValue { get; set; }
        [Required]
        public double SaleTotalItems { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public IList<ItemSaleViewModel> SaleItems { get; set; }
    }
}
