using Dashboard.Domain.Models;

namespace Dashboard.Repository.CustomerRepository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<bool> HasSales(int customerId);
    }
}
