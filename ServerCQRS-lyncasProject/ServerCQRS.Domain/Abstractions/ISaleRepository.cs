using ServerCQRS.Domain.Entities;

namespace ServerCQRS.Domain.Abstractions
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetSales();
        Task<Sale> GetSaleById(int saleId);
        Task<Sale> AddSale(Sale sale);
        void UpdateSale(Sale sale);
        Task<Sale> DeleteSale(int saleId);
    }
}
