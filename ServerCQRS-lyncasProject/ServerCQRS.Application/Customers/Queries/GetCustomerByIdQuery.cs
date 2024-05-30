using MediatR;
using ServerCQRS.Application.Members.Queries;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Application.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; set; }

        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
        {
            private readonly ICustomerDapperRepository _customerDapperRepository;

            public GetCustomerByIdQueryHandler(ICustomerDapperRepository customerDapperRepository)
            {
                _customerDapperRepository = customerDapperRepository;
            }

            public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                var customer = await _customerDapperRepository.GetCustomerById(request.Id);
                return customer;
            }
        }
    }
}
