using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;
using Dashboard.Domain.ViewModels;

namespace Dashboard.Dashboard.Service.SaleService
{
    public interface ISaleService
    {
        Task<List<SaleViewModel>> GetAllAsync();
        Task<SaleWithItemsViewModel> GetByIdAsync(int id);
        Task<Sale> UpdateAsync(SaleDto model, int id);
    }
}
