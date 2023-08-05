using ISAT.Server.Data;
using ISAT.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISAT.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SexualOrientationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SexualOrientationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SexualOrientation
        [HttpGet]
        public async Task<ActionResult<List<SexualOrientation>>> GetSexualOrientations()
        {
            return await _context.SexualOrientations.ToListAsync();
        }

        // GET: api/SexualOrientation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SexualOrientation>> GetSexualOrientation(Guid id)
        {
            var sexualOrientation = await _context.SexualOrientations.FindAsync(id);

            if (sexualOrientation == null)
            {
                return NotFound();
            }

            return Ok((SexualOrientation)sexualOrientation);
        }


        // POST: api/SexualOrientation        
        [HttpPost]
        public async Task<ActionResult<SexualOrientation>> PostSexualOrientation(SexualOrientation sexualOrientation)
        {
            _context.SexualOrientations.Add(sexualOrientation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSexualOrientation", new { id = sexualOrientation.Id }, sexualOrientation);
        }

        // PUT: api/SexualOrientation/5        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSexualOrientation(Guid id, SexualOrientation sexualOrientation)
        {
            if (id != sexualOrientation.Id)
            {
                return BadRequest();
            }

            _context.Entry(sexualOrientation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SexualOrientationExists(id))
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

        // DELETE: api/SexualOrientation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSexualOrientation(Guid id)
        {
            var sexualOrientation = await _context.SexualOrientations.FindAsync(id);
            if (sexualOrientation == null)
            {
                return NotFound();
            }

            _context.SexualOrientations.Remove(sexualOrientation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SexualOrientationExists(Guid id)
        {
            return _context.SexualOrientations.Any(e => e.Id == id);
        }
    }
}
