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
            try
            {
                var customer = await Task.FromResult(_repository.GetAll().ToList());
                var customerViewModel = _mapper.Map<List<CustomerViewModel>>(customer);
                return customerViewModel;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while getting customers.", ex);
            }
        }
        public async Task<List<CustomerViewModel>> GetAllAsync() 
        {
            try
            {
                var customer = await _customerRepository.GetAllAsync();
                var CustomerViewModel = _mapper.Map<List<CustomerViewModel>>(customer);
                return CustomerViewModel;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while getting all customers.", ex);
            }
        }

        public async Task<CustomerViewModel> GetByIdAsync(int id)
        {
            try
            {
                var customer = await Task.FromResult(_repository.GetById(id));
                var customerViewModel = _mapper.Map<CustomerViewModel>(customer);
                return customerViewModel;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while getting customers by Id.", ex);
            }
        }

        public async Task<Customer> CreateAsync(CustomerDto model)
        {
            try
            {
                var customer = _mapper.Map<Customer>(model);
                return await Task.FromResult(_repository.Create(customer));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while creating customer.", ex);
            }
        }

        public async Task<Customer> UpdateAsync(CustomerDto model, int id)
        {
            try
            {
                var customer = await Task.FromResult(_repository.GetById(id));
                _mapper.Map(model, customer);
                return await Task.FromResult(_repository.Update(customer));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while updating customer.", ex);
            }
        }

        public async Task<Customer> DeleteAsync(int id)
        {
            try
            {
                var customer = await Task.FromResult(_repository.GetById(id));
                _repository.Delete(customer);
                return customer;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while soft deleting customer.", ex);
            }
        }

        public async Task<Customer> VerifyDeleteOrSoftDeleteAsync(int id)
        {
            try
            {
                var customer = await Task.FromResult(_repository.GetById(id));
                if (customer == null)
                    return null;

                bool hasSales = await _customerRepository.HasSales(id);
                
                if (hasSales)
                    return await SoftDeleteAsync(customer);
                
                return _repository.Delete(customer);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while verify soft deleting customer.", ex);
            }
        }

        public async Task<Customer> SoftDeleteAsync(Customer obj)
        {
            try
            {
                obj.SoftDeleted = true;
                obj.DeletedAt = DateTime.Now;
                return await Task.FromResult(_repository.Update(obj));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while soft deleting customer.", ex);
            }
        }
    }
}
