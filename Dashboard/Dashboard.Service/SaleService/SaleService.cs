using Dashboard.Domain.ViewModels;
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
            var sale = new Sale();

            sale.SaleDate = saleVM.SaleDate;
            sale.BillingDate = saleVM.BillingDate;
            sale.SaleTotalValue = saleVM.SaleTotalValue;
            sale.SaleTotalItems = saleVM.SaleTotalItems;
            sale.CustomerId = saleVM.CustomerId;

            var saleItemsNew = new List<ItemSale>();

            saleItemsNew = saleVM.SaleItems.Select(itemVM => new ItemSale
            {
                Description = itemVM.Description,
                Quantity = itemVM.Quantity,
                UnityValue = itemVM.UnityValue,
                TotalValue = itemVM.TotalValue
            }).ToList();

            sale.SaleItems = saleItemsNew;

            return await _saleRepository.Create(sale);
        }

        public async Task<Sale> UpdateAsync(SaleViewModel saleVM, int id)
        {
            var sale = await _saleRepository.GetById(id);

            if (sale == null)
                return null;

            sale.SaleDate = saleVM.SaleDate;
            sale.BillingDate = saleVM.BillingDate;
            sale.SaleTotalValue = saleVM.SaleTotalValue;
            sale.SaleTotalItems = saleVM.SaleTotalItems;
            sale.CustomerId = saleVM.CustomerId;

            var itemsToRemove = sale.SaleItems.Where(item => !saleVM.SaleItems.Any(x => x.Id == item.Id)).ToList();
            foreach (var itemToRemove in itemsToRemove)
            {
                sale.SaleItems.Remove(itemToRemove);
            }

            foreach (var itemVM in saleVM.SaleItems)
            {
                var item = sale.SaleItems.FirstOrDefault(i => i.Id == itemVM.Id);

                if (item != null)
                {
                    item.Description = itemVM.Description;
                    item.Quantity = itemVM.Quantity;
                    item.UnityValue = itemVM.UnityValue;
                    item.TotalValue = itemVM.TotalValue;
                }
                else
                {
                    var newItem = new ItemSale
                    {
                        Description = itemVM.Description,
                        Quantity = itemVM.Quantity,
                        UnityValue = itemVM.UnityValue,
                        TotalValue = itemVM.TotalValue
                    };
                    sale.SaleItems.Add(newItem);
                }
            }
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
