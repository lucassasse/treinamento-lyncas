using CustomerApiOnion.Domain.Models;

namespace CustomerApiOnion.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task<bool> Post(Customer customer);
        Task<bool> Update(Customer customer);
        Task<bool> Delete(int id);
    }
}
