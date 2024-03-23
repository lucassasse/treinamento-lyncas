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
