using Domain.Models;

namespace Dashboard.Repository.CustomerRepository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAsync();
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetById(int id);
        Task<Customer> Create(Customer customer);
        Task<Customer> Update(Customer customer);
        Task<Customer> Delete(Customer customer);

        Task<bool> HasSales(int customerId);
    }
}
