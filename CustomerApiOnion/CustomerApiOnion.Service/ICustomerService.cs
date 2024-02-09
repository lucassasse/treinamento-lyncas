using CustomerApiOnion.Domain.ViewModels;

namespace CustomerApiOnion.Service
{
    public interface ICustomerService
    {
        Task<List<CustomerViewModel>> GetAllAsync();
        Task<CustomerViewModel> GetByIdAsync(int id);
        Task<bool> PostAsync(CustomerViewModel customerViewModel);
        Task<bool> UpdateAsync(CustomerViewModel customerViewModel);
        Task<bool> DeleteAsync(int id);
    }
}
