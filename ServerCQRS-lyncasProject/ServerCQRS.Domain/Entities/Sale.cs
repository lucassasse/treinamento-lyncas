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
        public List<ItemSale>? SaleItems { get; private set; }

        public Sale(DateTime saleDate, DateTime billingDate, double saleTotalValue, double saleTotalItems, int customerId, List<ItemSale> saleItems)
        {
            ValidateDomain(saleDate, billingDate, saleTotalValue, saleTotalItems, customerId, saleItems);
        }

        public Sale() { }

        [JsonConstructor]
        public Sale(int id, DateTime saleDate, DateTime billingDate, double saleTotalValue, double saleTotalItems, int customerId, List<ItemSale> saleItems)
        {
            DomainValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(saleDate, billingDate, saleTotalValue, saleTotalItems, customerId, saleItems);
        }

        public void Update(DateTime saleDate, DateTime billingDate, double saleTotalValue, double saleTotalItems, int customerId, List<ItemSale> saleItems)
        {
            ValidateDomain(saleDate, billingDate, saleTotalValue, saleTotalItems, customerId, saleItems);
        }

        private void ValidateDomain(DateTime saleDate, DateTime billingDate, double saleTotalValue, double saleTotalItems, int customerId, List<ItemSale> saleItems)
        {
            // Possibilidade de adicionar mais várias validações

            SaleDate = saleDate;
            BillingDate = billingDate;
            SaleTotalValue = saleTotalValue;
            SaleTotalItems = saleTotalItems;
            CustomerId = customerId;
            //Customer = customer;
            SaleItems = saleItems;
        }
    }
}
