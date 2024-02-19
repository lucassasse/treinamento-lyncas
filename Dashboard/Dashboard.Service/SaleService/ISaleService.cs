using Dashboard.Domain.ViewModels;
using Dashboard.Domain.Models;
using Domain.Models.ViewModels;

namespace Dashboard.Service.SaleService
{
    public interface ISaleService
    {
        Task<List<SaleWithCustomerDto>> GetAllAsync();
        Task<Sale> GetByIdAsync(int id);
        Task<Sale> CreateAsync(SaleDto saleViewModel);
        Task<Sale> UpdateAsync(SaleDto saleViewModel, int id);
        Task<Sale> DeleteAsync(int id);
    }
}
