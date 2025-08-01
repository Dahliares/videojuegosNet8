using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Videojuegos.Domain;
using Videojuegos.Insfrastructure;

namespace Videojuegos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideojuegosController : ControllerBase
    {
        private readonly VideojuegosDbContext _context;

        public VideojuegosController(VideojuegosDbContext context)
        {
            _context = context;
        }

        // GET: api/Videojuegos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Videojuego>>> GetAll()
        {
            return await _context.Videojuegos.ToListAsync();
        }

        // GET: api/Videojuegos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Videojuego>> GetById(int id)
        {
            var videojuego = await _context.Videojuegos.FindAsync(id);

            if (videojuego == null)
                return NotFound();

            return videojuego;
        }

        // POST: api/Videojuegos
        [HttpPost]
        public async Task<ActionResult<Videojuego>> Create(Videojuego videojuego)
        {
            _context.Videojuegos.Add(videojuego);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = videojuego.Id }, videojuego);
        }

        // PUT: api/Videojuegos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Videojuego videojuego)
        {
            if (id != videojuego.Id)
                return BadRequest();

            _context.Entry(videojuego).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideojuegoExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Videojuegos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var videojuego = await _context.Videojuegos.FindAsync(id);
            if (videojuego == null)
                return NotFound();

            _context.Videojuegos.Remove(videojuego);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideojuegoExists(int id)
        {
            return _context.Videojuegos.Any(e => e.Id == id);
        }
    }
}
