using Dashboard.Domain.Data;
using Dashboard.Domain.Models;
using Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Repository.CustomerRepository
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customer.IgnoreQueryFilters().ToListAsync(); //Ignora o filtro SoftDelete
        }

        public async Task<bool> HasSales(int customerId)
        {
            return await _context.Customer
                .AnyAsync(c => c.Id == customerId && c.Sales.Count > 0);
        }
    }
}
