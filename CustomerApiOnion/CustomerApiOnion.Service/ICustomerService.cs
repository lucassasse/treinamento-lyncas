using CustomerApiOnion.Domain.Models;
using CustomerApiOnion.Domain.ViewModels;

namespace CustomerApiOnion.Service
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> PostAsync(CustomerViewModel customerViewModel);
        Task<Customer> UpdateAsync(CustomerViewModel customerViewModel, int id);
        Task<Customer> DeleteAsync(int id);
    }
}
