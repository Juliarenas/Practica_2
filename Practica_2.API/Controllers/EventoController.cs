
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica_2.API.Data;
using Practica_2.Shared.Entities;


namespace Practica_2.API.Controllers
{
    [ApiController]
    [Route("/api/eventos")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;

        public EventoController(DataContext context) {
        
            _context = context;
        
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Events.ToListAsync());


        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            

            var evento = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);

            if (evento == null)
            {


                return NotFound();
            }

            return Ok(evento);


        }



        [HttpPost]
        public async Task<ActionResult> Post(Evento evento)
        {

            _context.Add(evento);
            await _context.SaveChangesAsync();
            return Ok(evento);

        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Evento evento)
        {
            if (id != evento.Id)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var evento = await _context.Events.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Events.Remove(evento);
            await _context.SaveChangesAsync();

            return Ok(evento);
        }

        private bool EventoExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }

    }
}
