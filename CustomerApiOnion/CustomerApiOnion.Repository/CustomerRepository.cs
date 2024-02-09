using CustomerApiOnion.Data;
using CustomerApiOnion.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApiOnion.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAll()
        {
            var result = await _context.Customer.ToListAsync();
            return result;
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Customer.FirstOrDefaultAsync(e => e.Id == id);
        }
        
        public async Task<Customer> Post(Customer customer)
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
    }
}
