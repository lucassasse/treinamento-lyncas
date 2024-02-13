namespace Domain.Models
{
    public class ItemSale
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double UnityValue { get; set; }
        public double TotalValue { get; set; }

        public int SaleId { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
