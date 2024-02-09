using CustomerApiOnion.Domain.Models;
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
            return Ok(await _customerService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            if (id == null)
                return NotFound();

            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }


        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [Bind("FullName,Email,Telephone,Cpf")] 
            CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.PostAsync(customer);
            }
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(
            [FromRoute] int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            await _customerService.UpdateAsync(customer);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerService.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            await _customerService.DeleteAsync(id);
            return Ok(customer);
        }
    }
}
