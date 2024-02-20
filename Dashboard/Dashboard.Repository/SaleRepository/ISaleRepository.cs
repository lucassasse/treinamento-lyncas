using Dashboard.Domain.ViewModels;
using Dashboard.Domain.Models;

namespace Dashboard.Repository.SaleRepository
{
    public interface ISaleRepository
    {
        Task<List<Sale>> GetAllIncluding();
        Task<Sale> GetById(int id);
    }
}
