using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServerCQRS.Application.Customers.Commands;
using ServerCQRS.Application.Customers.Queries;
using ServerCQRS.Application.Members.Commands;
using ServerCQRS.Application.Members.Queries;
using ServerCQRS.Domain.Entities;

namespace ServerCQRS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var query = new GetCustomersQuery();
            var customer = await _mediator.Send(query);

            return Ok(customer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var query = new GetCustomerByIdQuery { Id = id };
            var customer = await _mediator.Send(query);

            return customer != null ? Ok(customer) : NotFound("Customer not found.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
        {
            var createdCustomer = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, UpdateCustomerCommand command)
        {
            command.Id = id;
            var updatedCustomer = await _mediator.Send(command);

            return updatedCustomer != null ? Ok(updatedCustomer) : NotFound("Customer not found");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletedCustomer(int id)
        {
            var command = new DeleteCustomerCommand { Id = id };
            var deletedCustomer = await _mediator.Send(command);

            return deletedCustomer != null ? Ok(deletedCustomer) : NotFound("Customer not found");
        }
    }
}
