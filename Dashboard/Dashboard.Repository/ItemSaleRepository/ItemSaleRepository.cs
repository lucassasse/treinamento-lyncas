//using Dashboard.Domain.Data;
//using Domain.Data;
//using Domain.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Dashboard.Repository.ItemSaleRepository
//{
//    public class ItemSaleRepository : BaseRepository, IItemSaleRepository
//    {
//        public ItemSaleRepository(AppDbContext context) : base(context)
//        {
//        }

//        public async Task<List<ItemSale>> GetAll()
//        {
//            return await _context.ItemSale.ToListAsync();
//        }

//        public async Task<ItemSale> GetById(int id)
//        {
//            return await _context.ItemSale.FirstOrDefaultAsync(e => e.Id == id);
//        }

//        public async Task<ItemSale> Create(ItemSale itemSale)
//        {
//            await _context.ItemSale.AddAsync(itemSale);
//            await _context.SaveChangesAsync();
//            return itemSale;
//        }

//        public async Task<ItemSale> Update(ItemSale itemSale)
//        {
//            _context.ItemSale.Update(itemSale);
//            await _context.SaveChangesAsync();
//            return itemSale;
//        }

//        public async Task<ItemSale> Delete(ItemSale itemSale)
//        {
//            _context.ItemSale.Remove(itemSale);
//            await _context.SaveChangesAsync();
//            return itemSale;
//        }
//    }
//}
