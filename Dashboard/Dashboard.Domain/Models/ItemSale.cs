using System.Text.Json.Serialization;

namespace Dashboard.Domain.Models
{
    public class ItemSale : BaseEntity
    {
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double UnityValue { get; set; }
        public double TotalValue { get; set; }

        public int SaleId { get; set; }
        [JsonIgnore]
        public virtual Sale Sale { get; set; }
    }
}
