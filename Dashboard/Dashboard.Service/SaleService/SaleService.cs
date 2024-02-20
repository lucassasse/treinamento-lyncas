using AutoMapper;
using Dashboard.Domain.ViewModels;
using Dashboard.Repository.SaleRepository;
using Dashboard.Domain.Models;
using Dashboard.Repository.RepositoryPattern;
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
            var sales = await _saleRepository.GetAllIncluding();
            var saleViewModels = _mapper.Map<List<SaleViewModel>>(sales);
            return saleViewModels;
        }

        public async Task<SaleWithItemsViewModel> GetByIdAsync(int id)
        {
            var sales = await _saleRepository.GetById(id);
            var saleViewModels = _mapper.Map<SaleWithItemsViewModel>(sales);
            return saleViewModels;
        }

        public async Task<Sale> CreateAsync(SaleDto model)
        {
            try
            {
                var sale = _mapper.Map<Sale>(model);

                return await Task.FromResult(_repository.Create(sale));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Sale> UpdateAsync(SaleDto model, int id)
        {
            var sale = await Task.FromResult(_repository.GetById(id));

            if (sale == null)
                return null;

            _mapper.Map(model, sale);

            return await Task.FromResult(_repository.Update(sale));
        }

        public async Task<Sale> DeleteAsync(int id)
        {
            try
            {
                var sale = await Task.FromResult(_repository.GetById(id));
                if (sale == null)
                    return null;

                await Task.FromResult(_repository.Delete(sale));
                return sale;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting sale with ID");
            }
        }
    }
}
