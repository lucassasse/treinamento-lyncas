using ServerCQRS.Domain.Validation;
using System.Text.Json.Serialization;

namespace ServerCQRS.Domain.Entities
{
    public sealed class ItemSale : Entity
    {
        public string Description { get; private set; }
        public int Quantity { get; private set; }
        public double UnityValue { get; private set; }
        public double TotalValue { get; private set; }
        public int SaleId { get; private set; }
        [JsonIgnore]
        public Sale Sale { get; private set; }

        public ItemSale(string description, int quantity, double unityValue, double totalValue, int saleId)
        {
            ValidateDomain(description, quantity, unityValue, totalValue, saleId);
        }

        public ItemSale() { }

        [JsonConstructor]
        public ItemSale(int id, string description, int quantity, double unityValue, double totalValue, int saleId)
        {
            DomainValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(description, quantity, unityValue, totalValue, saleId);
        }

        public void Update(string description, int quantity, double unityValue, double totalValue, int saleId, Sale sale)
        {
            ValidateDomain(description, quantity, unityValue, totalValue, saleId);
        }

        private void ValidateDomain(string description, int quantity, double unityValue, double totalValue, int saleId)
        {
            // Possibilidade de adicionar mais várias validações

            Description = description;
            Quantity = quantity;
            UnityValue = unityValue;
            TotalValue = totalValue;
            SaleId = saleId;
        }
    }
}
