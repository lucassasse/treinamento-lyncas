using AutoMapper;
using Dashboard.Repository.CustomerRepository;
using Dashboard.Domain.Models;
using Dashboard.Domain.ViewModels;
using Dashboard.Domain.Dtos;
using Dashboard.Service.Service;

namespace Dashboard.Service.CustomerService
{
    public class CustomerService : Service<Customer, CustomerDto, CustomerViewModel, ICustomerRepository>, ICustomerService
    {

        public CustomerService(ICustomerRepository repository, IMapper mapper) : base(repository, mapper)
        {
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
                var customer = await _repository.GetAllAsync();
                var CustomerViewModel = _mapper.Map<List<CustomerViewModel>>(customer);
                return CustomerViewModel;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while getting all customers.", ex);
            }
        }

        public async Task<Customer> VerifyDeleteOrSoftDeleteAsync(int id)
        {
            try
            {
                var customer = await Task.FromResult(_repository.GetById(id));
                if (customer == null)
                    return null;

                bool hasSales = await _repository.HasSales(id);
                
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
