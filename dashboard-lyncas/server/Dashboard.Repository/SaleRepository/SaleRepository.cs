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

        public IQueryable<Sale> GetAllIncluding()
        {
            return _context.Sale
                .Include(x => x.Customer);
        }

        public override Sale GetById(int id)
        {
            return _context.Sale
                .Include(x => x.SaleItems)
                .FirstOrDefault(e => e.Id == id);
        }
    }
}