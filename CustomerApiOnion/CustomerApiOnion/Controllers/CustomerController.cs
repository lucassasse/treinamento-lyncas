using CustomerApiOnion.Domain.ViewModels;
using CustomerApiOnion.Service;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApiOnion.Controllers
{
    [ApiController]
    [Route(template: "customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var customers = await _customerService.GetAllAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Invalid ID");

                var customer = await _customerService.GetByIdAsync(id);
                if (customer == null)
                    return NotFound("Customer not found");

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _customerService.PostAsync(customer);
                    return Ok(customer);
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
        public async Task<IActionResult> Put(CustomerViewModel customerVM, [FromRoute] int id)
        {
            try
            {
                var existingCustomer = await _customerService.GetByIdAsync(id);
                if (existingCustomer == null)
                    return NotFound("Customer not found");

                var updatedCustomer = await _customerService.UpdateAsync(customerVM, id);
                return Ok(updatedCustomer);
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
                var deletedCustomer = await _customerService.DeleteAsync(id);
                if (deletedCustomer == null)
                    return NotFound("Customer not found");

                return Ok(deletedCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
