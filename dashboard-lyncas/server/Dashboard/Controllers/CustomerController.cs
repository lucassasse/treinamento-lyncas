using Dashboard.Service.CustomerService;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Domain.Dtos;
using Dashboard.Domain.ViewModels;
using Dashboard.Domain.Pagination;

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

                var customer = _customerService.GetById(id);
                if (customer == null)
                    return NotFound("Customer not found");

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> GetByPagination([FromBody] PaginationModel paginationModel)
        {
            try
            {
                var (pagedCustomer, totalCount) = await _customerService.GetByPagination(paginationModel.Page, paginationModel.NumberPerPage, paginationModel.Filter);

                var response = new
                {
                    Data = pagedCustomer,
                    TotalCount = totalCount
                };

                return Ok(response);
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
                    var createdCustomer = _customerService.Create(customer);
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
                var existingCustomer = _customerService.GetById(id);
                if (existingCustomer == null)
                    return NotFound("Customer not found");

                _customerService.Update(customer, id);
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
                //Chama o método que verifica a existência de 'Sales' --- E aquele método chama 'Delete' ou 'SoftDelete'
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
