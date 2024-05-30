using MediatR;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Application.Sales.Commands
{
    public sealed class UpdateSaleCommand : SaleCommandBase
    {
        public int Id { get; set; }

        public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, Sale>
        {
            private readonly IUnitOfWork _unitOfWork;

            public UpdateSaleCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Sale> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
            {
                var existingSale = await _unitOfWork.SaleRepository.GetSaleById(request.Id);

                if (existingSale is null)
                    throw new InvalidOperationException("Sale not found");

                existingSale.Update(request.SaleDate, request.BillingDate, request.SaleTotalValue, request.SaleTotalItems, request.CustomerId, request.SaleItems);

                _unitOfWork.SaleRepository.UpdateSale(existingSale);
                await _unitOfWork.CommitAsync();

                return existingSale;
            }
        }
    }
}
