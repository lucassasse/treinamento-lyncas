using Dashboard.Domain.Models;
using Dashboard.Repository.Repository;

namespace Dashboard.Repository.SaleRepository
{
    public interface ISaleRepository : IRepository<Sale>
    {
        Task<List<Sale>> GetAllIncluding();
    }
}
