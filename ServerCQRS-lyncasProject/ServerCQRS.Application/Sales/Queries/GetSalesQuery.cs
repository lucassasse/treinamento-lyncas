using MediatR;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Application.Sales.Queries
{
    public class GetSalesQuery : IRequest<IEnumerable<Sale>>
    {
        public class GetSalesQueryHandler : IRequestHandler<GetSalesQuery, IEnumerable<Sale>>
        {
            private readonly ISaleDapperRepository _saleDapperRepository;

            public GetSalesQueryHandler(ISaleDapperRepository saleDapperRepository)
            {
                _saleDapperRepository = saleDapperRepository;
            }

            public async Task<IEnumerable<Sale>> Handle(GetSalesQuery request, CancellationToken cancellationToken)
            {
                var sales = await _saleDapperRepository.GetSales();
                return sales;
            }
        }
    }
}
