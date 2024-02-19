using Dashboard.Service.CustomerService;
using Dashboard.Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("/api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<List<Customer>> GetCustomersAsync()
        {
            var customer = await _customerService.GetAsync();
            return customer;
        }

        [HttpGet("all")]
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            var customer = await _customerService.GetAllAsync();
            return customer;
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
        public async Task<IActionResult> Create([FromBody] CustomerDto customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _customerService.CreateAsync(customer);
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
        public async Task<IActionResult> Put([FromBody] CustomerDto customer, [FromRoute] int id)
        {
            try
            {
                var existingCustomer = await _customerService.GetByIdAsync(id);
                if (existingCustomer == null)
                    return NotFound("Customer not found");

                var updatedCustomer = await _customerService.UpdateAsync(customer, id);
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
                //Chama o método que verifica a existência de 'Sales' --- Este método chama 'Delete' ou 'SoftDelete'
                var deletedCustomer = await _customerService.VerifyDeleteOrSoftDeleteAsync(id);
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
