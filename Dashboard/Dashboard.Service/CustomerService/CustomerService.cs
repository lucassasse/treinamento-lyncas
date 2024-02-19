using AutoMapper;
using Dashboard.Repository.CustomerRepository;
using Dashboard.Repository.RepositoryPattern;
using Dashboard.Domain.Models;
using Domain.Models.ViewModels;

namespace Dashboard.Service.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Customer> _repository;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IRepository<Customer> repository)// :base(customerRepository)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<Customer>> GetAsync()
        {
            return await Task.FromResult(_repository.GetAll().ToList());
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await Task.FromResult(_repository.Get(id));
        }

        public async Task<Customer> CreateAsync(CustomerDto model)
        {
            var customer = _mapper.Map<Customer>(model);

            return await Task.FromResult(_repository.Create(customer));
        }

        public async Task<Customer> UpdateAsync(CustomerDto model, int id)
        {
            var customer = await Task.FromResult(_repository.Get(id));

            _mapper.Map(model, customer);

            return await Task.FromResult(_repository.Update(customer));
        }

        public async Task<Customer> DeleteAsync(int id)
        {
            var customer = await Task.FromResult(_repository.Get(id));
            _repository.Delete(customer);
            return customer;
        }



        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> VerifyDeleteOrSoftDeleteAsync(int id)
        {
            var customer = await Task.FromResult(_repository.Get(id));

            if (customer == null)
            {
                return null;
            }

            bool hasSales = await _customerRepository.HasSales(id);

            if (hasSales)
                return await SoftDeleteAsync(customer);

            return _repository.Delete(customer);
        }

        public async Task<Customer> SoftDeleteAsync(Customer obj)
        {
            obj.SoftDeleted = true;
            obj.DeletedAt = DateTime.Now;

            return await Task.FromResult(_repository.Update(obj));
        }
    }
}
