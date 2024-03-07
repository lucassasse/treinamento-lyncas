using Dashboard.Domain.Models;
using Dashboard.Repository.Repository;

namespace Dashboard.Repository.CustomerRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<List<Customer>> GetByPagination(int page, int pageNumber);
        Task<bool> HasSales(int customerId);
    }
}
