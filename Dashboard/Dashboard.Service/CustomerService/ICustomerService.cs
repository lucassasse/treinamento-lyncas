using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;
using Dashboard.Domain.ViewModels;

namespace Dashboard.Service.CustomerService
{
    public interface ICustomerService
    {
        Task<List<CustomerViewModel>> GetAsync();
        Task<CustomerViewModel> GetByIdAsync(int id);
        Task<Customer> CreateAsync(CustomerDto customerDto);
        Task<Customer> UpdateAsync(CustomerDto customerDto, int id);
        Task<Customer> DeleteAsync(int id);

        Task<List<CustomerViewModel>> GetAllAsync();
        Task<Customer> VerifyDeleteOrSoftDeleteAsync(int id);
        Task<Customer> SoftDeleteAsync(Customer obj);
    }
}
