using AutoMapper;
using Dashboard.Repository.CustomerRepository;
using Dashboard.Domain.Models;
using Dashboard.Domain.ViewModels;
using Dashboard.Domain.Dtos;
using Dashboard.Service.Service;
using Dashboard.Domain.Pagination;
using Microsoft.EntityFrameworkCore;

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
                var x = _repository.GetAll()
                    .Where(x => x.SoftDeleted != true)
                    .ToList();
                var customer = await Task.FromResult(x);
                var customerViewModel = _mapper.Map<List<CustomerViewModel>>(customer);
                return customerViewModel;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while getting customers.", ex);
            }
        }

        public async Task<List<Customer>> GetByPagination(int page, int pageNumber)
        {
            try
            {
                return await _repository.GetByPagination(page, pageNumber);

                //var totalCount = await _repository.GetByPagination().CountAsync();

                //var data = _repository.GetByPagination()
                //  .Skip((pagelist.Page - 1) * pagelist.PageSize)
                //  .Take(pagelist.PageSize)
                //  .ToList();

                //var customerViewModel = _mapper.Map<List<CustomerViewModel>>(data);

                //return new PageList<CustomerViewModel>(customerViewModel, pagelist.Page, pagelist.PageSize, totalCount);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while getting paginated customers.", ex);
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
