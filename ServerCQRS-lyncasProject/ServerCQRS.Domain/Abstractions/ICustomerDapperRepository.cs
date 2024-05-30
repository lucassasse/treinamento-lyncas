using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Domain.Abstractions
{
    public interface ICustomerDapperRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
    }
}
