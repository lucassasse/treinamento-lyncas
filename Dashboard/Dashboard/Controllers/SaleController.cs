using Domain.Models;
using Domain.Models.ViewModels;
using Dashboard.Service.SaleService;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Domain.ViewModels;

namespace Dashboard.Controllers
{
    [Route("/api/[controller]")]
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<List<SaleWithCustomerViewModel>> GetSalesAsync()
        {
            var sale = await _saleService.GetAllAsync();
            return sale;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Invalid ID");

                var sale = await _saleService.GetByIdAsync(id);
                if (sale == null)
                    return NotFound("Sale not found");

                return Ok(sale);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaleViewModel sale)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _saleService.CreateAsync(sale);
                    return Ok(sale);
                }
                else
                {
                    return BadRequest("Invalid model state");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] SaleViewModel SaleVM, [FromRoute] int id)
        {
            try
            {
                var existingSale = await _saleService.GetByIdAsync(id);
                if (existingSale == null)
                    return NotFound("Sale not found");

                var updatedSale = await _saleService.UpdateAsync(SaleVM, id);
                return Ok(updatedSale);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var deletedSale = await _saleService.DeleteAsync(id);
                if (deletedSale == null)
                    return NotFound("Sale not found");

                return Ok(deletedSale);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
