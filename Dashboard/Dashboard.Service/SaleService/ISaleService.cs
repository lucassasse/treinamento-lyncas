using Dashboard.Domain.ViewModels;
using Dashboard.Domain.Models;
using Dashboard.Domain.Dtos;

namespace Dashboard.Dashboard.Service.SaleService
{
    public interface ISaleService
    {
        Task<List<SaleViewModel>> GetAllAsync();
        Task<SaleWithItemsViewModel> GetByIdAsync(int id);
        Task<Sale> CreateAsync(SaleViewModel saleViewModel);
        Task<Sale> UpdateAsync(SaleDto saleDto, int id);
        Task<Sale> DeleteAsync(int id);
    }
}
