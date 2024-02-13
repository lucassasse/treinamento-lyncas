//using Domain.Models.ViewModels;
//using Domain.Models;
//using Microsoft.AspNetCore.Mvc;
//using Dashboard.Service.ItemSaleService;

//namespace Dashboard.Controllers
//{
//    [Route("/api/[controller]")]
//    public class ItemSaleController : Controller
//    {
//        private readonly ItemSaleService _itemSaleService;

//        public ItemSaleController(IItemSaleService itemSaleService)
//        {
//            _itemSaleService = itemSaleService;
//        }

//        [HttpGet]
//        public async Task<List<ItemSale>> GetSalesAsync()
//        {
//            var itemSale = await _itemSaleService.GetAllAsync();
//            return itemSale;
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
//        {
//            try
//            {
//                if (id == null)
//                    return BadRequest("Invalid ID");

//                var itemSale = await _itemSaleService.GetByIdAsync(id);
//                if (itemSale == null)
//                    return NotFound("ItemSale not found");

//                return Ok(itemSale);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal Server Error: {ex.Message}");
//            }
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] ItemSaleViewModel itemSale)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    await _itemSaleService.CreateAsync(itemSale);
//                    return Ok(itemSale);
//                }
//                else
//                {
//                    return BadRequest("Invalid model state");
//                }
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal Server Error: {ex.Message}");
//            }
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> Put([FromBody] ItemSaleViewModel ItemSaleVM, [FromRoute] int id)
//        {
//            try
//            {
//                var existingItemSale = await _itemSaleService.GetByIdAsync(id);
//                if (existingItemSale == null)
//                    return NotFound("ItemSale not found");

//                var updatedItemSale = await _itemSaleService.UpdateAsync(ItemSaleVM, id);
//                return Ok(updatedItemSale);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal Server Error: {ex.Message}");
//            }
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete([FromRoute] int id)
//        {
//            try
//            {
//                var deletedItemSale = await _itemSaleService.DeleteAsync(id);
//                if (deletedItemSale == null)
//                    return NotFound("ItemSale not found");

//                return Ok(deletedItemSale);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal Server Error: {ex.Message}");
//            }
//        }
//    }
//}
