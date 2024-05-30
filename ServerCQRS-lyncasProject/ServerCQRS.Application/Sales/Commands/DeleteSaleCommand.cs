using MediatR;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Application.Sales.Commands
{
    public sealed class DeleteSaleCommand : IRequest<Sale>
    {
        public int Id { get; set; }

        public class DeleteSaleCommandHandler : IRequestHandler<DeleteSaleCommand, Sale>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteSaleCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Sale> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
            {
                var deletedSale = await _unitOfWork.SaleRepository.DeleteSale(request.Id);

                if (deletedSale is null)
                    throw new InvalidOperationException("Sale not found.");

                await _unitOfWork.CommitAsync();
                return deletedSale;
            }
        }
    }
}
