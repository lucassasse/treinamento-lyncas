using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServerCQRS.Application.Sales.Commands;
using ServerCQRS.Application.Sales.Queries;

namespace ServerCQRS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSales()
        {
            var query = new GetSalesQuery();
            var sales = await _mediator.Send(query);

            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale(int id)
        {
            var query = new GetSaleByIdQuery { Id = id };
            var sale = await _mediator.Send(query);

            return sale != null ? Ok(sale) : NotFound("Sale not found.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale(CreateSaleCommand command)
        {
            var createdSale = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetSale), new { id = createdSale.Id }, createdSale);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSale(int id, UpdateSaleCommand command)
        {
            command.Id = id;
            var updatedSale = await _mediator.Send(command);

            return updatedSale != null ? Ok(updatedSale) : NotFound("Sale not found");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletedSale(int id)
        {
            var command = new DeleteSaleCommand { Id = id };
            var deletedSale = await _mediator.Send(command);

            return deletedSale != null ? Ok(deletedSale) : NotFound("Sale not found");
        }
    }
}
