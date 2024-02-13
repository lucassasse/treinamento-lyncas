using Domain.Models;
using Domain.Models.ViewModels;

namespace Dashboard.Service.SaleService
{
    public interface ISaleService
    {
        Task<List<Sale>> GetAllAsync();
        Task<Sale> GetByIdAsync(int id);
        Task<Sale> CreateAsync(SaleViewModel saleViewModel);
        Task<Sale> UpdateAsync(SaleViewModel saleViewModel, int id);
        Task<Sale> DeleteAsync(int id);
    }
}
