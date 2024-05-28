using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Domain.Abstractions
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int customerId);
        Task<Customer> AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Task<Customer> DeleteCustomer(int customerId);
    }
}
