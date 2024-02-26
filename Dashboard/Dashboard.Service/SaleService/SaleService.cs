using AutoMapper;
using Dashboard.Domain.ViewModels;
using Dashboard.Repository.SaleRepository;
using Dashboard.Domain.Models;
using Dashboard.Domain.Dtos;
using Dashboard.Service.Service;

namespace Dashboard.Service.SaleService
{
    public class SaleService : Service<Sale, SaleDto, SaleViewModel, ISaleRepository>, ISaleService
    {

        public SaleService(ISaleRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<List<SaleViewModel>> GetAllAsync()
        {
            try
            {
                var sales = await _repository.GetAllIncluding();
                var saleViewModels = _mapper.Map<List<SaleViewModel>>(sales);
                return saleViewModels;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting list sales");
            }
        }

        public async Task<SaleWithItemsViewModel> GetByIdAsync(int id)
        {
            try
            {
                var sales = _repository.GetById(id);
                var saleViewModels = _mapper.Map<SaleWithItemsViewModel>(sales);
                return saleViewModels;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting sale with ID");
            }
        }

        public override Sale Update(SaleDto model, int id)
        {
            try
            {
                var sale = _repository.GetById(id);

                if (sale == null)
                    return null;

                _mapper.Map(model, sale);

                return _repository.Update(sale);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating sale with ID");
            }
        }
    }
}
