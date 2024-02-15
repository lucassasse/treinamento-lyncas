using AutoMapper;
using Dashboard.Repository.CustomerRepository;
using Domain.Models;
using Domain.Models.ViewModels;

namespace Dashboard.Service.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
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

        public async Task<Customer> CreateAsync(CustomerViewModel model)
        {
            var customer = _mapper.Map<Customer>(model);

            return await _customerRepository.Create(customer);
        }

        public async Task<Customer> UpdateAsync(CustomerViewModel model, int id)
        {
            var customer = await _customerRepository.GetById(id);

            _mapper.Map(model, customer);

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
                   return await SoftDeleteAsync(customer);

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
