using Dashboard.Domain.ViewModels;
using Dashboard.Domain.Models;

namespace Dashboard.Dashboard.Service.SaleService
{
    public interface ISaleService
    {
        Task<List<SaleViewModel>> GetAllAsync();
        Task<Sale> GetByIdAsync(int id);
        Task<Sale> CreateAsync(SaleViewModel saleViewModel);
        Task<Sale> UpdateAsync(SaleDto saleViewModel, int id);
        Task<Sale> DeleteAsync(int id);
    }
}
