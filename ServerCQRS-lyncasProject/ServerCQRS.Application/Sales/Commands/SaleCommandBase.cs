using MediatR;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Application.Sales.Commands
{
    public abstract class SaleCommandBase : IRequest<Sale>
    {
        public DateTime SaleDate { get; set; }
        public DateTime BillingDate { get; set; }
        public double SaleTotalValue { get; set; }
        public double SaleTotalItems { get; set; }
        public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
        public List<ItemSale> SaleItems { get; set; }
    }
}
