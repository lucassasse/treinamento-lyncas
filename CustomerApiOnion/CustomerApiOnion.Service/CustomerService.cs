using CustomerApiOnion.Domain.Models;
using CustomerApiOnion.Domain.ViewModels;
using CustomerApiOnion.Repository;

namespace CustomerApiOnion.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            var customerList = new List<Customer>();
            var result = await _customerRepository.GetAll();
            foreach (var item in result)
            {
                customerList.Add(new Customer
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    Email = item.Email,
                    Telephone = item.Telephone,
                    Cpf = item.Cpf
                });
            }
            return customerList;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerRepository.GetById(id);
        }
        
        public async Task<Customer> PostAsync(CustomerViewModel customer)
        {
            var obj = new Customer();

            obj.FullName = customer.FullName;
            obj.Email = customer.Email;
            obj.Telephone = customer.Telephone;
            obj.Cpf = customer.Cpf;

            return await _customerRepository.Post(obj);
        }
        
        public async Task<Customer> UpdateAsync(CustomerViewModel customer, int id)
        {
            var obj = await _customerRepository.GetById(id);

            obj.FullName = customer.FullName;
            obj.Email = customer.Email;
            obj.Telephone = customer.Telephone;
            obj.Cpf = customer.Cpf;

            return await _customerRepository.Update(obj);
        }
        
        public async Task<Customer> DeleteAsync(int id)
        {
            var customer = await _customerRepository.GetById(id);
            await _customerRepository.Delete(customer);
            return customer;
        }
    }
}
