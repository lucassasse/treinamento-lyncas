using AutoMapper;
using Dashboard.Repository.CustomerRepository;
using Dashboard.Repository.RepositoryPattern;
using Dashboard.Domain.Models;
using Dashboard.Domain.Dtos;
using Dashboard.Domain.ViewModels;

namespace Dashboard.Service.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Customer> _repository;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IRepository<Customer> repository)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<CustomerViewModel>> GetAsync()
        {
            var customer = await Task.FromResult(_repository.GetAll().ToList());
            var customerViewModel = _mapper.Map<List<CustomerViewModel>>(customer);
            return customerViewModel;
        }

        public async Task<CustomerViewModel> GetByIdAsync(int id)
        {
            var customer = await Task.FromResult(_repository.GetById(id));
            var customerViewModel = _mapper.Map<CustomerViewModel>(customer);
            return customerViewModel;
        }

        public async Task<Customer> CreateAsync(CustomerDto model)
        {
            var customer = _mapper.Map<Customer>(model);

            return await Task.FromResult(_repository.Create(customer));
        }

        public async Task<Customer> UpdateAsync(CustomerDto model, int id)
        {
            var customer = await Task.FromResult(_repository.GetById(id));

            _mapper.Map(model, customer);

            return await Task.FromResult(_repository.Update(customer));
        }

        public async Task<Customer> DeleteAsync(int id)
        {
            var customer = await Task.FromResult(_repository.GetById(id));
            _repository.Delete(customer);
            return customer;
        }



        public async Task<List<CustomerViewModel>> GetAllAsync()
        {
            var customer = await _customerRepository.GetAllAsync();
            var CustomerViewModel = _mapper.Map<List<CustomerViewModel>>(customer);
            return new List<CustomerViewModel>();
        }

        public async Task<Customer> VerifyDeleteOrSoftDeleteAsync(int id)
        {
            var customer = await Task.FromResult(_repository.GetById(id));

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
