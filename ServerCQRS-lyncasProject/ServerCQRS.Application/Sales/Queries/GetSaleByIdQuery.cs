using MediatR;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Application.Sales.Queries
{
    public class GetSaleByIdQuery : IRequest<Sale>
    {
        public int Id { get; set; }

        public class GetSaleByIdQueryHandler : IRequestHandler<GetSaleByIdQuery, Sale>
        {
            private readonly ISaleDapperRepository _saleDapperRepository;

            public GetSaleByIdQueryHandler(ISaleDapperRepository saleDapperRepository)
            {
                _saleDapperRepository = saleDapperRepository;
            }

            public async Task<Sale> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
            {
                var sale = await _saleDapperRepository.GetSaleById(request.Id);
                return sale;
            }
        }
    }
}
