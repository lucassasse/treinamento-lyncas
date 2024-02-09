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
            var result = await _context.Customer.Where(e => e.Id == id).FirstOrDefaultAsync();
            return result;
        }
        
        public async Task<bool> Post(Customer customer)
        {
            try
            {
                await _context.Customer.AddAsync(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(Customer customer)
        {
            try
            {
                _context.Customer.Update(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var result = await _context.Customer.Where(e => e.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.Customer.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
