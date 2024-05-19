using Dashboard.Domain.ViewModels;
using Dashboard.Service.SaleService;
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
        public ActionResult<List<SaleViewModel>> GetSalesAsync()
        {
            try
            {
                var sale = _saleService.GetAllAsync();
                return Ok(sale);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
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
                    var createdSale = _saleService.Create(model);
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

                if (!model.SaleItems.Any())
                    return NotFound("Your sale must have at least one item");

                _saleService.Update(model, id);
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
                var deletedSale = _saleService.Delete(id);
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
