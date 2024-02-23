using AutoMapper;
using Dashboard.Domain.ViewModels;
using Dashboard.Repository.SaleRepository;
using Dashboard.Domain.Models;
using Dashboard.Repository.Repository;
using Dashboard.Dashboard.Service.SaleService;
using Dashboard.Domain.Dtos;

namespace Dashboard.Service.SaleService
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Sale> _repository;

        public SaleService(ISaleRepository saleRepository, IMapper mapper, IRepository<Sale> repository)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<SaleViewModel>> GetAllAsync()
        {
            try
            {
                var sales = await _saleRepository.GetAllIncluding();
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
                var sales = await _saleRepository.GetById(id);
                var saleViewModels = _mapper.Map<SaleWithItemsViewModel>(sales);
                return saleViewModels;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting sale with ID");
            }
        }

        public async Task<Sale> UpdateAsync(SaleDto model, int id)
        {
            try
            {
                var sale = await Task.FromResult(_repository.GetById(id));

                if (sale == null)
                    return null;

                _mapper.Map(model, sale);

                return await Task.FromResult(_repository.Update(sale));
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating sale with ID");
            }
        }
    }
}
