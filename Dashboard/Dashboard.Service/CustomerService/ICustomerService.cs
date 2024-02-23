using Dashboard.Domain.Models;
using Dashboard.Domain.ViewModels;

namespace Dashboard.Service.CustomerService
{
    public interface ICustomerService
    {
        Task<List<CustomerViewModel>> GetAsync();
        Task<List<CustomerViewModel>> GetAllAsync();
        Task<Customer> VerifyDeleteOrSoftDeleteAsync(int id);
        Task<Customer> SoftDeleteAsync(Customer obj);
    }
}
