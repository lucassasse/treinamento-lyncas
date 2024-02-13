namespace Domain.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime BillingDate { get; set; }
        public double SaleTotalValue { get; set; }
        public double SaleTotalItems { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual IList<ItemSale> SaleItems { get; set; }
    }
}
