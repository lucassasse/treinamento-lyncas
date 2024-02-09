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

        public async Task<List<CustomerViewModel>> GetAllAsync()
        {
            var customerList = new List<CustomerViewModel>();
            var result = await _customerRepository.GetAll();
            foreach (var item in result)
            {
                customerList.Add(new CustomerViewModel
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

        public async Task<CustomerViewModel> GetByIdAsync(int id)
        {
            var result = await _customerRepository.GetById(id);
            var customerVM = new CustomerViewModel();
            
            customerVM.Id = id;
            customerVM.FullName = result.FullName;
            customerVM.Email = result.Email;
            customerVM.Telephone = result.Telephone;
            customerVM.Cpf = result.Cpf;

            return customerVM;
        }
        
        public async Task<bool> PostAsync(
            CustomerViewModel customerVM)
        {
            try
            {
                var obj = new Customer();
                obj.Id = customerVM.Id;
                obj.FullName = customerVM.FullName;
                obj.Email = customerVM.Email;
                obj.Telephone = customerVM.Telephone;
                obj.Cpf = customerVM.Cpf;

                var result = await _customerRepository.Post(obj);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(
            CustomerViewModel customerVM)
        {
            try
            {
                var obj = new Customer();
                obj.Id = customerVM.Id;
                obj.FullName = customerVM.FullName;
                obj.Email = customerVM.Email;
                obj.Telephone = customerVM.Telephone;
                obj.Cpf = customerVM.Cpf;

                var result = await _customerRepository.Update(obj);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _customerRepository.Delete(id);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
