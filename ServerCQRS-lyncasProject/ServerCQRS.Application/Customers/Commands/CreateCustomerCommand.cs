using MediatR;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Application.Customers.Commands
{
    public class CreateCustomerCommand : CustomerCommandBase
    {
        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
        {
            private readonly IUnitOfWork _unitOfWork;

            public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var newCustomer = new Customer(request.FullName, request.Email, request.Telephone, request.Cpf, request.SoftDeleted, request.DeletedAt, request.Sale);

                await _unitOfWork.CustomerRepository.AddCustomer(newCustomer);
                await _unitOfWork.CommitAsync();

                return newCustomer;
            }
        }
    }
}
