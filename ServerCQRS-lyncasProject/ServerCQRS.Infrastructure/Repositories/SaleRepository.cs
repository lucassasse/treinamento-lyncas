using Microsoft.EntityFrameworkCore;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;
using ServerCQRS.Infrastructure.Context;

namespace ServerCQRS.Infrastructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        protected readonly AppDbContext db;

        public SaleRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<Sale> AddSale(Sale sale)
        {
            if (sale is null)
                throw new ArgumentNullException(nameof(sale));

            await db.Sale.AddAsync(sale);
            return sale;
        }

        public async Task<Sale> DeleteSale(int saleId)
        {
            var sale = await GetSaleById(saleId);

            if (sale is null)
                throw new InvalidOperationException("Sale not found");

            db.Sale.Remove(sale);
            return sale;
        }

        public async Task<Sale> GetSaleById(int id)
        {
            var sale = await db.Sale.FindAsync(id);

            if (sale is null)
                throw new InvalidOperationException("Sale not found");

            return sale;
        }

        public async Task<IEnumerable<Sale>> GetSales()
        {
            var saleList = await db.Sale.ToListAsync();
            return saleList ?? Enumerable.Empty<Sale>();
        }

        public void UpdateSale(Sale sale)
        {
            if (sale is null)
                throw new ArgumentNullException(nameof(sale));

            db.Sale.Update(sale);
        }
    }
}
