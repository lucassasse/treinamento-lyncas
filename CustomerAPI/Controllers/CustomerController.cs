using CustomerAPI.Data;
using CustomerAPI.Models;
using CustomerAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Controllers
{
    [ApiController]
    [Route(template:"customer")]
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;
        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customer = await _context
                .Customer
                .AsNoTracking()
                .ToListAsync();

            return Ok(customer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var customer = await context
                .Customer
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromServices] AppDbContext context,
            [FromBody] CreateCustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = new Customer
            {
                FullName = model.FullName,
                Email = model.Email,
                Telephone = model.Telephone,
                Cpf = model.Cpf,
            };

            try
            {
                await context.Customer.AddAsync(customer);
                await context.SaveChangesAsync();
                return Created($"customer/{customer.Id}", customer);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(
            [FromServices] AppDbContext context,
            [FromBody] CreateCustomerViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = await context.Customer.FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null)
                return NotFound();

            try
            {
                customer.Email = model.Email;
                customer.Telephone = model.Telephone;

                context.Customer.Update(customer);
                await context.SaveChangesAsync();
                return Ok(customer);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var customer = await context.Customer.FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null)
                return NotFound();

            try
            {
                context.Customer.Remove(customer);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
