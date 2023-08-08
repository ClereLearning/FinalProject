using ISAT.Server.Data;
using ISAT.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISAT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntervieweeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IntervieweeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Interviewee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interviewee>>> GetInterviewees()
        {
            return await _context.Interviewees.ToListAsync();
        }

        // GET: api/Interviewee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interviewee>> GetInterviewee(Guid id)
        {
            var interviewee = await _context.Interviewees.FindAsync(id);
            /*
             * var interviewee = await _context.Interviewees
                .Include(g => g.Gender)
                .Include(s => s.SexualOrientation)
                .FirstOrDefaultAsync(i => i.Id == id);
            */


            if (interviewee == null)
            {
                return NotFound();
            }

            return interviewee;
        }

        // PUT: api/Interviewee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterviewee(Guid id, Interviewee interviewee)
        {
            if (id != interviewee.Id)
            {
                return BadRequest();
            }

            interviewee.GenderId = interviewee.Gender.Id;
            interviewee.Gender = null;
            interviewee.SexualOrientationId = interviewee.SexualOrientation.Id;
            interviewee.SexualOrientation = null;

            _context.Entry(interviewee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntervieweeExists(id))
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

        // POST: api/Interviewee
        [HttpPost]
        public async Task<ActionResult<Interviewee>> PostInterviewee(Interviewee interviewee)
        {
            interviewee.GenderId = interviewee.Gender.Id;
            interviewee.Gender = null;
            interviewee.SexualOrientationId = interviewee.SexualOrientation.Id;
            interviewee.SexualOrientation = null;
            _context.Interviewees.Add(interviewee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterviewee", new { id = interviewee.Id }, interviewee);
        }

        // DELETE: api/Interviewee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterviewee(Guid id)
        {
            var interviewee = await _context.Interviewees.FindAsync(id);
            if (interviewee == null)
            {
                return NotFound();
            }

            _context.Interviewees.Remove(interviewee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IntervieweeExists(Guid id)
        {
            return _context.Interviewees.Any(e => e.Id == id);
        }

        // GET: api/Interview/sexualorientation
        [HttpGet("sexualorientation")]
        public async Task<ActionResult<IEnumerable<SexualOrientation>>> GetSexualOrientations()
        {
            return await _context.SexualOrientations.ToListAsync();
        }

        // GET: api/Interview/gender
        [HttpGet("gender")]
        public async Task<ActionResult<IEnumerable<Gender>>> GetGenders()
        {
            return await _context.Genders.ToListAsync();
        }

        // GET: api/Interviewee/email@email.com
        [HttpGet("{email}/{PhoneNumber}")]
        public async Task<ActionResult<IEnumerable<Interviewee>>> GetInterviewees(string email, string PhoneNumber)
        {
            return await _context.Interviewees.Where(i => i.Email == email || i.PhoneNumber == PhoneNumber).ToListAsync();
        }
               
    }
}
