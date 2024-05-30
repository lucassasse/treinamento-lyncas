using MediatR;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Application.Sales.Commands
{
    public sealed class CreateSaleCommand : SaleCommandBase
    {
        public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, Sale>
        {
            private readonly IUnitOfWork _unitOfWork;

            public CreateSaleCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Sale> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
            {
                var newSale = new Sale(request.SaleDate, request.BillingDate, request.SaleTotalValue, request.SaleTotalItems, request.CustomerId, request.SaleItems);

                await _unitOfWork.SaleRepository.AddSale(newSale);
                await _unitOfWork.CommitAsync();

                return newSale;
            }
        }
    }
}
