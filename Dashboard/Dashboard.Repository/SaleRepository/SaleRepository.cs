using Dashboard.Domain.Data;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Repository.SaleRepository
{
    public class SaleRepository : BaseRepository, ISaleRepository
    {
        public SaleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Sale>> GetAll()
        {
            return await _context.Sale.ToListAsync();
        }

        public async Task<Sale> GetById(int id)
        {
            return await _context.Sale.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Sale> Create(Sale sale)
        {
            await _context.Sale.AddAsync(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        public async Task<Sale> Update(Sale sale)
        {
            _context.Sale.Update(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        public async Task<Sale> Delete(Sale sale)
        {
            _context.Sale.Remove(sale);
            await _context.SaveChangesAsync();
            return sale;
        }
    }
}
