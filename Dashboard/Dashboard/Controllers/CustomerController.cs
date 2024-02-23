using Dashboard.Service.CustomerService;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Domain.Dtos;
using Dashboard.Domain.ViewModels;
using Dashboard.Domain.Models;
using Dashboard.Service.Service;

namespace Dashboard.Controllers
{
    [Route("/api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IService<Customer, CustomerDto, CustomerViewModel> _service;

        public CustomerController(ICustomerService customerService, IService<Customer, CustomerDto, CustomerViewModel> service)
        {
            _customerService = customerService;
            _service = service;
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

                var customer = _service.GetById(id);
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
                    var createdCustomer = _service.Create(customer);
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
                var existingCustomer = _service.GetById(id);
                if (existingCustomer == null)
                    return NotFound("Customer not found");

                _service.Update(customer, id);
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
