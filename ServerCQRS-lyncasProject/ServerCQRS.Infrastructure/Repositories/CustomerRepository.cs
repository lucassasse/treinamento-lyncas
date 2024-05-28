using Microsoft.EntityFrameworkCore;
using ServerCQRS.Domain.Abstractions;
using ServerCQRS.Domain.Entities;
using ServerCQRS.Infrastructure.Context;

namespace ServerCQRS.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly AppDbContext db;

        public CustomerRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            if (customer is null)
                throw new ArgumentNullException(nameof(customer));

            await db.Customer.AddAsync(customer);
            return customer;
        }

        public async Task<Customer> DeleteCustomer(int customerId)
        {
            var customer = await GetCustomerById(customerId);

            if (customer is null)
                throw new InvalidOperationException("Customer not found");

            db.Customer.Remove(customer);
            return customer;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await db.Customer.FindAsync(id);

            if (customer is null)
                throw new InvalidOperationException("Customer not found");

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customerList = await db.Customer.ToListAsync();
            return customerList ?? Enumerable.Empty<Customer>();
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer is null)
                throw new ArgumentNullException(nameof(customer));

            db.Customer.Update(customer);
        }
    }
}
