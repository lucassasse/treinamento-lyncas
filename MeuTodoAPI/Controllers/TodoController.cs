using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MeuTodoAPI.ViewModels;
using MeuTodoAPI.Models;
using MeuTodoAPI.Data;

namespace MeuTodoAPI.Controllers
{
    [ApiController]
    [Route("todos")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {
            var todo = await context
                .Todos
                .AsNoTracking()
                .ToListAsync();

            return Ok(todo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var todo = await context
                .Todos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return todo == null ? NotFound() : Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateTodoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var todo = new Todo
            {
                Date = DateTime.Now,
                Done = false,
                Title = model.Title
            }; // deixar dentro de Services

            try
            {
                await context.Todos.AddAsync(todo);
                await context.SaveChangesAsync();
                return Created($"todos/{todo.Id}", todo);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateTodoViewModel model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);

            if (todo == null)
                return NotFound();

            try
            {
                todo.Title = model.Title;

                context.Todos.Update(todo);
                await context.SaveChangesAsync();
                return Ok(todo);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.Todos.Remove(todo);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{todoId}/subtasks")]
        public async Task<IActionResult> GetSubtasksAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int todoId)
        {
            var todo = await context.Todos
                .Include(t => t.Subtasks)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == todoId);

            if (todo == null)
                return NotFound();

            var subtasks = todo.Subtasks;

            return Ok(subtasks);
        }

        [HttpPost("{todoId}/subtasks")]
        public async Task<IActionResult> AddSubtaskAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateSubtaskViewModel model,
            [FromRoute] int todoId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var todo = await context.Todos
                .Include(t => t.Subtasks)
                .FirstOrDefaultAsync(x => x.Id == todoId);

            if (todo == null)
                return NotFound();

            var subtask = new Subtask
            {
                Description = model.Description,
                Done = false,
                TodoId = todoId
            };

            try
            {
                todo.Subtasks.Add(subtask);
                await context.SaveChangesAsync();
                return Created($"todos/{todoId}/subtasks/{subtask.Id}", subtask);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{todoId}/subtasks/{subtaskId}")]
        public async Task<IActionResult> UpdateSubtaskAsync(
            [FromServices] AppDbContext context,
            [FromBody] UpdateSubtaskViewModel model,
            [FromRoute] int todoId,
            [FromRoute] int subtaskId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var todo = await context.Todos
                .Include(t => t.Subtasks)
                .FirstOrDefaultAsync(x => x.Id == todoId);

            if (todo == null)
                return NotFound();

            var subtask = todo.Subtasks.FirstOrDefault(s => s.Id == subtaskId);

            if (subtask == null)
                return NotFound();

            try
            {
                subtask.Description = model.Description;
                subtask.Done = model.Done;

                await context.SaveChangesAsync();
                return Ok(subtask);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{todoId}/subtasks/{subtaskId}")]
        public async Task<IActionResult> DeleteSubtaskAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int todoId,
            [FromRoute] int subtaskId)
        {
            var todo = await context.Todos
                .Include(t => t.Subtasks)
                .FirstOrDefaultAsync(x => x.Id == todoId);

            if (todo == null)
                return NotFound();

            var subtask = todo.Subtasks.FirstOrDefault(s => s.Id == subtaskId);

            if (subtask == null)
                return NotFound();

            try
            {
                context.Subtasks.Remove(subtask);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
