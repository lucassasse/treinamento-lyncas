using Dashboard.Repository.SaleRepository;
using Domain.Models;
using Domain.Models.ViewModels;

namespace Dashboard.Service.SaleService
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<List<Sale>> GetAllAsync()
        {
            return await _saleRepository.GetAll();
        }

        public async Task<Sale> GetByIdAsync(int id)
        {
            return await _saleRepository.GetById(id);
        }

        public async Task<Sale> CreateAsync(SaleViewModel saleVM)
        {
            var sale = new Sale();

            sale.SaleDate = saleVM.SaleDate;
            sale.BillingDate = saleVM.BillingDate;
            sale.SaleTotalValue = saleVM.SaleTotalValue;
            sale.SaleTotalItems = saleVM.SaleTotalItems;
            sale.CustomerId = saleVM.CustomerId;

            var saleItems = new List<ItemSale>();

            saleItems = saleVM.SaleItems.Select(itemVM => new ItemSale
            {
                Description = itemVM.Description,
                Quantity = itemVM.Quantity,
                UnityValue = itemVM.UnityValue,
                TotalValue = itemVM.TotalValue
            }).ToList();

            sale.SaleItems = saleItems;

            return await _saleRepository.Create(sale);
        }

        public async Task<Sale> UpdateAsync(SaleViewModel saleVM, int id)
        {
            var sale = await _saleRepository.GetById(id);

            sale.SaleDate = saleVM.SaleDate;
            sale.BillingDate = saleVM.BillingDate;
            sale.SaleTotalValue = saleVM.SaleTotalValue;
            sale.SaleTotalItems = saleVM.SaleTotalItems;
            sale.CustomerId = saleVM.CustomerId;

            return await _saleRepository.Update(sale);
        }

        public async Task<Sale> DeleteAsync(int id)
        {
            var sale = await _saleRepository.GetById(id);
            await _saleRepository.Delete(sale);
            return sale;
        }
    }
}
