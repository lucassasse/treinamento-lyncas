using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;
using Dashboard.Domain.ViewModels;
using Dashboard.Service.Service;

namespace Dashboard.Service.CustomerService
{
    public interface ICustomerService : IService<Customer, CustomerDto, CustomerViewModel>
    {
        Task<List<CustomerViewModel>> GetAsync();
        Task<Customer> VerifyDeleteOrSoftDeleteAsync(int id);
        Task<Customer> SoftDeleteAsync(Customer obj);
        Task<(List<Customer> Data, int TotalCount)> GetByPagination(int page, int numberPerPage, string filter);
    }
}
