using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica_2.API.Data;
using Practica_2.Shared.Entities;

namespace Practica_2.API.Controllers
{
    [ApiController]
    [Route("/api/Participantes")]
    public class ParticipanteController : ControllerBase
    {
        private readonly DataContext _context;

        public ParticipanteController(DataContext context)
        {

            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Participantes.ToListAsync());


        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {



            var participante = await _context.Participantes.FirstOrDefaultAsync(x => x.Id == id);

            if (participante == null)
            {


                return NotFound();
            }

            return Ok(participante);


        }



        [HttpPost]
        public async Task<ActionResult> Post(Participante participante)
        {

            _context.Add(participante);
            await _context.SaveChangesAsync();
            return Ok(participante);

        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Participante participante)
        {
            if (id != participante.Id)
            {
                return BadRequest();
            }

            _context.Entry(participante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipanteExists(id))
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
            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null)
            {
                return NotFound();
            }

            _context.Participantes.Remove(participante);
            await _context.SaveChangesAsync();

            return Ok(participante);
        }

        private bool ParticipanteExists(int id)
        {
            return _context.Participantes.Any(e => e.Id == id);
        }
    }
}
