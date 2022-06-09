using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToDoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDo>>> Get()
        {
            return await _context.ToDo.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDo>> GetById(long id)
        {
            var todo = await _context.ToDo.FirstOrDefaultAsync(x => x.Id == id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return BadRequest();
            }

            _context.Entry(toDo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ToDo>> Create(ToDo toDo)
        {
            _context.ToDo.Add(toDo);
            await _context.SaveChangesAsync();

            return Ok(toDo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDo>> Delete(int id)
        {
            var todo = await _context.ToDo.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            _context.ToDo.Remove(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        private bool TodoItemExists(int id)
        {
            return _context.ToDo.Any(e => e.Id == id);
        }
    }
}