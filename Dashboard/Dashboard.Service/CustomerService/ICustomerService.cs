using Dashboard.Domain.Models;
using Domain.ViewModels;

namespace Dashboard.Service.CustomerService
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> CreateAsync(CustomerDto customerViewModel);
        Task<Customer> UpdateAsync(CustomerDto customerViewModel, int id);
        Task<Customer> DeleteAsync(int id);

        Task<List<Customer>> GetAllAsync();
        Task<Customer> VerifyDeleteOrSoftDeleteAsync(int id);
        Task<Customer> SoftDeleteAsync(Customer obj);
    }
}
