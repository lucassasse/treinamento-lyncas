using Dashboard.Domain.Models;
using Dashboard.Domain.ViewModels;

namespace Dashboard.Repository.CustomerRepository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<bool> HasSales(int customerId);
    }
}
