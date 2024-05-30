using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Domain.Abstractions
{
    public interface ISaleDapperRepository
    {
        Task<IEnumerable<Sale>> GetSales();
        Task<Sale> GetSaleById(int id);
    }
}
