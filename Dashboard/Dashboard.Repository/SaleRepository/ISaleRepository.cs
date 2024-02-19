using Dashboard.Domain.ViewModels;
using Dashboard.Domain.Models;

namespace Dashboard.Repository.SaleRepository
{
    public interface ISaleRepository
    {
        Task<List<SaleViewModel>> GetAll();
        Task<Sale> GetById(int id);
        //Task<Sale> Create(Sale sale);
        //Task<Sale> Update(Sale sale);
        //Task<Sale> Delete(Sale sale);
    }
}
