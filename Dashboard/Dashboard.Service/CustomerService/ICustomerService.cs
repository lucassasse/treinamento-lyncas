using Domain.Models;
using Domain.Models.ViewModels;

namespace Dashboard.Service.CustomerService
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAsync();
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> CreateAsync(CustomerViewModel customerViewModel);
        Task<Customer> VerifyDeleteOrSoftDeleteAsync(int id);
        Task<Customer> UpdateAsync(CustomerViewModel customerViewModel, int id);
        Task<Customer> DeleteAsync(int id);
    }
}
