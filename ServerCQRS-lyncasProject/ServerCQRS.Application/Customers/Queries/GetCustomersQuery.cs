using MediatR;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Application.Customers.Queries
{
    public class GetCustomersQuery : IRequest<IEnumerable<Customer>>
    {
        public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
        {
            private readonly ICustomerDapperRepository _customerDapperRepository;

            public GetCustomersQueryHandler(ICustomerDapperRepository customerDapperRepository)
            {
                _customerDapperRepository = customerDapperRepository;
            }

            public async Task<IEnumerable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
            {
                var customers = await _customerDapperRepository.GetCustomers();
                return customers;
            }
        }
    }
}
