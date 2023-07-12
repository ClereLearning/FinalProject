using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISAT.Server.Data;
using ISAT.Shared.Models;

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
        public async Task<ActionResult<List<Interviewee>>> GetInterviewees()
        {
            return await _context.Interviewees.ToListAsync();
        }

        // GET: api/Interviewee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interviewee>> GetInterviewee(int id)
        {
            var interviewee = await _context.Interviewees.FindAsync(id);

            if (interviewee == null)
            {
                return NotFound();
            }

            return Ok( (Interviewee) interviewee);
        }

       
        // POST: api/Interviewee        
        [HttpPost]
        public async Task<ActionResult<Interviewee>> PostInterviewee(Interviewee interviewee)
        {
            _context.Interviewees.Add(interviewee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterviewee", new { id = interviewee.Id }, interviewee);
        }

        // PUT: api/Interviewee/5        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterviewee(int id, Interviewee interviewee)
        {
            if (id != interviewee.Id)
            {
                return BadRequest();
            }

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

        // DELETE: api/Interviewee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterviewee(int id)
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

        private bool IntervieweeExists(int id)
        {
            return _context.Interviewees.Any(e => e.Id == id);
        }
    }
}
