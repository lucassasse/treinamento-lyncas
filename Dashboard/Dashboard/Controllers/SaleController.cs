using Dashboard.Domain.ViewModels;
using Dashboard.Dashboard.Service.SaleService;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Domain.Dtos;

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
        public async Task<ActionResult<List<SaleViewModel>>> GetSalesAsync()
        {
            try
            {
                var sale = await _saleService.GetAllAsync();
                return Ok(sale);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
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
        public async Task<IActionResult> Create([FromBody] SaleDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdSale = await _saleService.CreateAsync(model);
                    var resourceUri = Url.Action("Get", new { id = createdSale.Id });
                    return Created(resourceUri, createdSale);
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
        public async Task<IActionResult> Put([FromBody] SaleDto model, [FromRoute] int id)
        {
            try
            {
                var existingSale = await _saleService.GetByIdAsync(id);
                if (existingSale == null)
                    return NotFound("Sale not found");

                await _saleService.UpdateAsync(model, id);
                return Ok();
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

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
