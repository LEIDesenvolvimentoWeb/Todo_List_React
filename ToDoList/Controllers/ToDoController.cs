using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.DTO;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly string diretoria;

        public ToDoController(ApplicationDbContext context)
        {
            _context = context;
            this.diretoria = Path.Combine(Directory.GetCurrentDirectory(), "Ficheiros");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetToDoDTO>>> Get()
        {
            var toDo = await _context.ToDo.Select(x => new GetToDoDTO
            {
                Id = x.Id,
                DataConclusao = x.DataConclusao.Value.ToString("MM/dd/yyyy HH:mm"),
                DataParaConcluir = x.DataParaConcluir.Value.ToString("MM/dd/yyyy HH:mm"),
                DataCriacao = x.DataCriacao.ToString("MM/dd/yyyy HH:mm"),
                Descricao = x.Descricao,
                Tipo = x.Tipo.Descricao,
                Ficheiro = x.Ficheiro,
                Directoria = x.Ficheiro == null ? null : diretoria + "\\" + x.Ficheiro,
                Titulo = x.Titulo
            }
            ).ToListAsync();

            toDo = toDo.OrderBy(x => x.DataConclusao).ToList();

            return toDo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetToDoDTO>> GetById(long id)
        {
            var todo = await _context.ToDo.Select(x => new GetToDoDTO
            {
                Id = x.Id,
                DataConclusao = x.DataConclusao.Value.ToString("MM/dd/yyyy HH:mm"),
                DataParaConcluir = x.DataParaConcluir.Value.ToString("MM/dd/yyyy HH:mm"),
                DataCriacao = x.DataCriacao.ToString("MM/dd/yyyy HH:mm"),
                Descricao = x.Descricao,
                Tipo = x.Tipo.Descricao,
                Ficheiro = x.Ficheiro,
                Directoria = x.Ficheiro == null ? null : diretoria + "\\" + x.Ficheiro,
                Titulo = x.Titulo
            }).FirstOrDefaultAsync(x => x.Id == id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _context.ToDo.FirstOrDefaultAsync(x => x.Id == id);

            if (task.DataConclusao == null)
            {
                return BadRequest();
            }

            task.DataConclusao = DateTime.Now;

            try
            {
                _context.Update(task);

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
        public async Task<ActionResult<ToDoDTO>> Create([FromForm] ToDoDTO toDo, IFormFile uploadFicheiro)
        {
            string caminhoCompletoFoto = "";
            bool existeFoto = false;
            string nomeFicheiro = null;

            if (uploadFicheiro != null)
            {
                //Gerar nome do ficheiro
                Guid guid = Guid.NewGuid();

                //Criação da Extensão Do Ficheiro
                string extensao = Path.GetExtension(uploadFicheiro.FileName).ToLower();
                nomeFicheiro = guid.ToString() + extensao;

                //Guardar o Ficheiro
                caminhoCompletoFoto = Path.Combine(diretoria, nomeFicheiro);

                existeFoto = true;
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var toDoNew = new ToDo
                    {
                        Titulo = toDo.Titulo,
                        Descricao = toDo.Descricao,
                        DataCriacao = DateTime.Now,
                        Ficheiro = nomeFicheiro,
                        DataConclusao = toDo.DataConclusao,
                        DataParaConcluir = toDo.DataParaConcluir,
                        TipoId = toDo.Tipo
                    };

                    _context.ToDo.Add(toDoNew);
                    await _context.SaveChangesAsync();

                    if (existeFoto)
                    {
                        //Validação da Existência do Directório
                        if (!Directory.Exists(diretoria))
                        {
                            Directory.CreateDirectory(diretoria);
                        }

                        using var stream = new FileStream(caminhoCompletoFoto, FileMode.Create);
                        await uploadFicheiro.CopyToAsync(stream);
                    }
                    return Ok(toDo);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
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