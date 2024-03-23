using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;
using Dashboard.Domain.ViewModels;
using Dashboard.Service.Service;

namespace Dashboard.Service.SaleService
{
    public interface ISaleService : IService<Sale, SaleDto, SaleViewModel>
    {
        List<SaleViewModel> GetAllAsync();
        Task<SaleWithItemsViewModel> GetByIdAsync(int id);
    }
}
