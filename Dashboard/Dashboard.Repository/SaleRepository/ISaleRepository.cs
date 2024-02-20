using Dashboard.Domain.ViewModels;
using Dashboard.Domain.Models;

namespace Dashboard.Repository.SaleRepository
{
    public interface ISaleRepository
    {
        Task<List<Sale>> GetAll();
        Task<Sale> GetById(int id);
    }
}
