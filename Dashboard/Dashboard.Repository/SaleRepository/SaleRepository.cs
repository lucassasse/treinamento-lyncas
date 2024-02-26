using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Dashboard.Domain.Models;
using Dashboard.Repository.Repository;

namespace Dashboard.Repository.SaleRepository
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Sale>> GetAllIncluding()
        {
            return await _context.Sale
                .Include(x => x.Customer)
                .ToListAsync();
        }

        public override Sale GetById(int id)
        {
            return _context.Sale
                .Include(x => x.SaleItems)
                .FirstOrDefault(e => e.Id == id);
        }
    }
}