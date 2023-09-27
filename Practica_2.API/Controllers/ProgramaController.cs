using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica_2.API.Data;
using Practica_2.Shared.Entities;

namespace Practica_2.API.Controllers
{

    [ApiController]
    [Route("/api/Programas")]
    public class ProgramaController : ControllerBase
    {
        private readonly DataContext _context;

        public ProgramaController(DataContext context)
        {

            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Programas.ToListAsync());


        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {



            var programa = await _context.Programas.FirstOrDefaultAsync(x => x.Id == id);

            if (programa == null)
            {


                return NotFound();
            }

            return Ok(programa);


        }



        [HttpPost]
        public async Task<ActionResult> Post(Programa programa)
        {

            _context.Add(programa);
            await _context.SaveChangesAsync();
            return Ok(programa);

        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Programa programa)
        {
            if (id != programa.Id)
            {
                return BadRequest();
            }

            _context.Entry(programa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramaExists(id))
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
            var programa = await _context.Programas.FindAsync(id);
            if (programa == null)
            {
                return NotFound();
            }

            _context.Programas.Remove(programa);
            await _context.SaveChangesAsync();

            return Ok(programa);
        }

        private bool ProgramaExists(int id)
        {
            return _context.Programas.Any(e => e.Id == id);
        }
    }
}
