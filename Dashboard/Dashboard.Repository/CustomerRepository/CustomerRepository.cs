using Dashboard.Domain.Models;
using Dashboard.Repository.Repository;
using Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Repository.CustomerRepository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Customer>> GetByPagination(int page, int pageNumber)
        {
            try
            {
                return await _context.Customer
                    .Skip((page -1) * pageNumber)
                    .Take(page)
                    .ToListAsync();

                //return _context.Customer.AsQueryable()
                //    .Where(x => x.SoftDeleted != true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when get customer by pagination. {ex.Message}");
                throw;
            }
        }

        public async Task<bool> HasSales(int customerId)
        {
            try
            {
                return await _context.Customer
                    .AnyAsync(c => c.Id == customerId && c.Sales.Count > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when checking whether the customer has sales. {ex.Message}");
                throw;
            }
        }
    }
}
