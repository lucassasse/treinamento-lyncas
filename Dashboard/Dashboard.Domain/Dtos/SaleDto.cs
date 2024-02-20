using System.ComponentModel.DataAnnotations;
using Dashboard.Domain.ViewModels;

namespace Dashboard.Domain.Dtos
{
    public class SaleDto
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        [Required]
        public double SaleTotalItems { get; set; }
        [Required]
        public DateTime BillingDate { get; set; }
        [Required]
        public double SaleTotalValue { get; set; }
        [Required]
        public IList<ItemSaleViewModel> SaleItems { get; set; }
    }
}
