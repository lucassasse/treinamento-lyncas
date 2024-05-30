using MediatR;
using ServerCQRS.Application.Members.Commands;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Application.Customers.Commands
{
    public sealed class DeleteCustomerCommand : CustomerCommandBase
    {
        public int Id { get; set; }

        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Customer>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Customer> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                var deletedCustomer = await _unitOfWork.CustomerRepository.DeleteCustomer(request.Id);

                if (deletedCustomer is null)
                    throw new InvalidOperationException("Customer not found.");

                await _unitOfWork.CommitAsync();
                return deletedCustomer;
            }
        }
    }
}
