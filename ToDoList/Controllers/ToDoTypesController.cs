using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.DTO;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToDoTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetToDoTypeDTO>>> Get()
        {
            return await _context.ToDoType.Select(x => new GetToDoTypeDTO { Id = x.Id, Descricao = x.Descricao }).ToListAsync();
        }
    }
}