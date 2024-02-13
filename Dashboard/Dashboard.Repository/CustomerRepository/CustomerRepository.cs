using Dashboard.Domain.Data;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Repository.CustomerRepository
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Customer>> GetAsync()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customer.IgnoreQueryFilters().ToListAsync(); //Ignora o filtro SoftDelete
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Customer.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Customer> Create(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Update(Customer customer)
        {
            _context.Customer.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Delete(Customer customer)
        {
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> HasSales(int customerId)
        {

            return await _context.Customer
                .AnyAsync(c => c.Id == customerId && c.Sales.Count > 0);
        }
    }
}
