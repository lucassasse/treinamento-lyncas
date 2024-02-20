using Dashboard.Domain.Data;
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Dashboard.Domain.Models;

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
            return await _context.Sale
                .Include(x => x.SaleItems)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}