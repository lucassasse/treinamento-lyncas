using Dashboard.Repository.CustomerRepository;
using Domain.Models;
using Domain.Models.ViewModels;

namespace Dashboard.Service.CustomerService
{
    public class CustomerService : ICustomerService //+2 metodos (VerifyExistItem + SoftDelete)
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetAsync()
        {
            return await _customerRepository.GetAsync();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerRepository.GetById(id);
        }

        public async Task<Customer> CreateAsync(CustomerViewModel customerVM)
        {
            var customer = new Customer();

            customer.FullName = customerVM.FullName;
            customer.Email = customerVM.Email;
            customer.Telephone = customerVM.Telephone;
            customer.Cpf = customerVM.Cpf;
            customer.SoftDeleted = false;
            
            return await _customerRepository.Create(customer);
        }

        public async Task<Customer> UpdateAsync(CustomerViewModel customerVM, int id)
        {
            var customer = await _customerRepository.GetById(id);

            customer.FullName = customerVM.FullName;
            customer.Email = customerVM.Email;
            customer.Telephone = customerVM.Telephone;
            customer.Cpf = customerVM.Cpf;

            return await _customerRepository.Update(customer);
        }

        public async Task<Customer> VerifyDeleteOrSoftDeleteAsync(int id)
        {
            var customer = await _customerRepository.GetById(id);

            if (customer == null)
            {
                return null;
            }

            bool hasSales = await _customerRepository.HasSales(id);

            if (hasSales)
            {
                   return await SoftDeleteAsync(customer);
            }
            return await DeleteAsync(id);
        }

        public async Task<Customer> DeleteAsync(int id)
        {
            var customer = await _customerRepository.GetById(id);
            await _customerRepository.Delete(customer);
            return customer;
        }

        public async Task<Customer> SoftDeleteAsync(Customer obj)
        {
            obj.SoftDeleted = true;
            obj.DeletedAt = DateTime.Now;

            return await _customerRepository.Update(obj);
        }
    }
}
