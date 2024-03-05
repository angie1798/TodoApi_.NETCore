using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly DataContext _context;
        public TodoController(DataContext context)
        {
            _context= context;
        }

        //busca todas las tareas guardadas 
        [HttpGet]
        public async Task<ActionResult<List<Tarea>>> GetTarea()
        {
            return Ok(await _context.Tareas.ToListAsync());
        }

        //agrega una nueva tarea a la lista
        [HttpPost]
        public async Task<ActionResult<List<Tarea>>> PostTarea(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
            return Ok(await _context.Tareas.ToListAsync());
        }

        //modifica una tarea (la marca como hecha)
        [HttpPut]
        public async Task<ActionResult<List<Tarea>>> PutTarea(Tarea tarea)
        {
            var tareaBuscada= await _context.Tareas.FindAsync(tarea.id);
            if (tareaBuscada == null)
                return BadRequest("No se encontró la tarea");

            tareaBuscada.chequeado= !tareaBuscada.chequeado;
            await _context.SaveChangesAsync();
            return Ok(await _context.Tareas.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Tarea>>> DeleteTarea(Tarea tarea)
        {
            var tareaBuscada = await _context.Tareas.FindAsync(tarea.id);
            if (tareaBuscada == null)
                return BadRequest("No se encontró la tarea");

            _context.Tareas.Remove(tareaBuscada);
            await _context.SaveChangesAsync();
            return Ok(await _context.Tareas.ToListAsync());
        }

    }//class

}//namesapce
