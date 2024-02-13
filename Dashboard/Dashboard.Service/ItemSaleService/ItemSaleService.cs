//using Dashboard.Repository.ItemSaleRepository;
//using Domain.Models;
//using Domain.Models.ViewModels;

//namespace Dashboard.Service.ItemSaleService
//{
//    public class ItemSaleService : IItemSaleService
//    {
//        private readonly IItemSaleRepository _itemSaleRepository;

//        public ItemSaleService(IItemSaleRepository itemSaleRepository)
//        {
//            _itemSaleRepository = itemSaleRepository;
//        }

//        public async Task<List<ItemSale>> GetAllAsync()
//        {
//            return await _itemSaleRepository.GetAll();
//        }

//        public async Task<ItemSale> GetByIdAsync(int id)
//        {
//            return await _itemSaleRepository.GetById(id);
//        }

//        public async Task<ItemSale> PostAsync(ItemSaleViewModel itemSaleVM)
//        {
//            var itemSale = new ItemSale();

//            itemSale.Description = itemSaleVM.Description;
//            itemSale.Quantity = itemSaleVM.Quantity;
//            itemSale.UnityValue = itemSaleVM.UnityValue;
//            itemSale.TotalValue = itemSaleVM.TotalValue;
//            //itemSale.SaleId = itemSaleVM.SaleId;

//            return await _itemSaleRepository.Post(itemSale);
//        }

//        public async Task<ItemSale> UpdateAsync(ItemSaleViewModel itemSaleVM, int id)
//        {
//            var itemSale = await _itemSaleRepository.GetById(id);

//            itemSale.Description = itemSaleVM.Description;
//            itemSale.Quantity = itemSaleVM.Quantity;
//            itemSale.UnityValue = itemSaleVM.UnityValue;
//            itemSale.TotalValue = itemSaleVM.TotalValue;
//            //itemSale.SaleId = itemSaleVM.SaleId;

//            return await _itemSaleRepository.Update(itemSale);
//        }

//        public async Task<ItemSale> DeleteAsync(int id)
//        {
//            var itemSale = await _itemSaleRepository.GetById(id);
//            await _itemSaleRepository.Delete(itemSale);
//            return itemSale;
//        }
//    }
//}
