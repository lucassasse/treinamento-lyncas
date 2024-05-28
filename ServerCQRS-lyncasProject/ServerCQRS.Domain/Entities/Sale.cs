using ServerCQRS.Domain.Validation;
using System.Text.Json.Serialization;

namespace ServerCQRS.Domain.Entities
{
    public sealed class Sale : Entity
    {
        public DateTime SaleDate { get; private set; }
        public DateTime BillingDate { get; private set; }
        public double SaleTotalValue { get; private set; }
        public double SaleTotalItems { get; private set; }
        public int CustomerId { get; private set; }
        //public Customer Customer { get; private set; }
        public List<ItemSale> SaleItems { get; private set; }

        public Sale(DateTime saleDate, DateTime billingDate, double SaleTotalValue, double SaleTotalItems, int CustomerId, List<ItemSale> saleItems)
        {
            ValidateDomain(saleDate, billingDate, SaleTotalValue, SaleTotalItems, CustomerId, saleItems);
        }

        public Sale() { }

        [JsonConstructor]
        public Sale(int id, DateTime saleDate, DateTime billingDate, double SaleTotalValue, double SaleTotalItems, int CustomerId, List<ItemSale> saleItems)
        {
            DomainValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(saleDate, billingDate, SaleTotalValue, SaleTotalItems, CustomerId, saleItems);
        }

        public void Update(DateTime saleDate, DateTime billingDate, double SaleTotalValue, double SaleTotalItems, int CustomerId, List<ItemSale> saleItems)
        {
            ValidateDomain(saleDate, billingDate, SaleTotalValue, SaleTotalItems, CustomerId, saleItems);
        }

        private void ValidateDomain(DateTime saleDate, DateTime billingDate, double SaleTotalValue, double SaleTotalItems, int CustomerId, List<ItemSale> saleItems)
        {
            // Possibilidade de adicionar mais várias validações

            SaleDate = saleDate;
            BillingDate = billingDate;
            SaleTotalValue = SaleTotalValue;
            SaleTotalItems = SaleTotalItems;
            CustomerId = CustomerId;
            //Customer = customer;
            SaleItems = saleItems;
        }
    }
}
