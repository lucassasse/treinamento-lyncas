using AutoMapper;
using Dashboard.Domain.ViewModels;
using Dashboard.Repository.SaleRepository;
using Domain.Models;
using Domain.Models.ViewModels;

namespace Dashboard.Service.SaleService
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public SaleService(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<List<SaleWithCustomerViewModel>> GetAllAsync()
        {
            return await _saleRepository.GetAll();
        }

        public async Task<Sale> GetByIdAsync(int id)
        {
            return await _saleRepository.GetById(id);
        }

        public async Task<Sale> CreateAsync(SaleViewModel saleVM)
        {
            try
            {
                var sale = _mapper.Map<Sale>(saleVM);

                return await _saleRepository.Create(sale);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Sale> UpdateAsync(SaleViewModel saleVM, int id)
        {
            var sale = await _saleRepository.GetById(id);

            if (sale == null)
                return null;

            _mapper.Map(saleVM, sale);

            return await _saleRepository.Update(sale);
        }

        public async Task<Sale> DeleteAsync(int id)
        {
            try
            {
                var sale = await _saleRepository.GetById(id);
                if (sale == null)
                    return null;

                await _saleRepository.Delete(sale);
                return sale;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting sale with ID");
            }
        }
    }
}
