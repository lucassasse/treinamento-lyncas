using CustomerApiOnion.Domain.Models;

namespace CustomerApiOnion.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task<Customer> Post(Customer customer);
        Task<Customer> Update(Customer customer);
        Task<Customer> Delete(Customer customer);
    }
}
