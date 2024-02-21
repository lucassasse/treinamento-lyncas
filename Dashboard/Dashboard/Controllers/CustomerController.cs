using Dashboard.Service.CustomerService;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Domain.Dtos;
using Dashboard.Domain.ViewModels;

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
        public async Task<ActionResult<List<CustomerViewModel>>> GetAsync()
        {
            try
            {
                var customer = await _customerService.GetAsync();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<CustomerViewModel>>> GetAllAsync()
        {
            try
            {
                var customer = await _customerService.GetAllAsync();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GatByIdAsync([FromRoute] int id)
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
                    var createdCustomer = await _customerService.CreateAsync(customer);
                    var resourceUri = Url.Action("Get", new { id = createdCustomer.Id });
                    return Created(resourceUri, createdCustomer);
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

                await _customerService.UpdateAsync(customer, id);
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
                //Chama o método que verifica a existência de 'Sales' --- Este método chama 'Delete' ou 'SoftDelete'
                var deletedCustomer = await _customerService.VerifyDeleteOrSoftDeleteAsync(id);
                if (deletedCustomer == null)
                    return NotFound("Customer not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
