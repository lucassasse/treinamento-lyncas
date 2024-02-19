using Domain.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Domain.ViewModels
{
    public class SaleWithCustomerDto
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
        public IList<ItemSaleDto> SaleItems { get; set; }
        [Required]
        public string CustomerName { get; set; }
    }
}
