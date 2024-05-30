using MediatR;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Application.Customers.Commands
{
    public sealed class UpdateCustomerCommand : CustomerCommandBase
    {
        public int Id { get; set; }

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
        {
            private readonly IUnitOfWork _unitOfWork;

            public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                var existingCustomer = await _unitOfWork.CustomerRepository.GetCustomerById(request.Id);

                if (existingCustomer is null)
                    throw new InvalidOperationException("Customer not found");

                existingCustomer.Update(request.FullName, request.Email, request.Telephone, request.Cpf, request.SoftDeleted, request.DeletedAt, request.Sale);
                _unitOfWork.CustomerRepository.UpdateCustomer(existingCustomer);
                await _unitOfWork.CommitAsync();

                return existingCustomer;
            }
        }
    }
}
