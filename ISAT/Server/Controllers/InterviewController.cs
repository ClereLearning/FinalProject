using ISAT.Server.Data;
using ISAT.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISAT.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InterviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Interview
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interview>>> GetInterviews()
        {
            //return await _context.Interviews.ToListAsync();
            return await _context.Interviews
                .Include("Interviewee")
                .Include("InterviewStatus")
                .ToListAsync();
        }


        // GET: api/Interview/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interview>> GetInterview(Guid id)
        {
            // var interview = await _context.Interviews.FindAsync(id);
            var interview = await _context.Interviews
                .Include(p => p.Interviewee)
                .Include(s => s.InterviewStatus)
                .Where(i => i.Id == id).FirstOrDefaultAsync();

            if (interview == null)
            {
                return NotFound();
            }

            return interview;
        }

        // PUT: api/Interview/5        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterview(Guid id, Interview interview)
        {
            if (id != interview.Id)
            {
                return BadRequest();
            }
            interview.InterviewStatus = null;
            interview.Interviewee = null;
            _context.Entry(interview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterviewExists(id))
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


        // POST: api/interview         
        [HttpPost]
        public async Task<ActionResult<Interview>> PostInterview(Interview interview)
        {
            _context.Interviews.Add(interview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterview", new { id = interview.Id }, interview);
        }

        // DELETE: api/Interview/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterview(Guid id)
        {
            var interview = await _context.Interviews.FindAsync(id);
            if (interview == null)
            {
                return NotFound();
            }

            _context.Interviews.Remove(interview);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InterviewExists(Guid id)
        {
            return _context.Interviews.Any(e => e.Id == id);
        }

        // GET: api/Interview/interviewees
        [HttpGet("interviewees")]
        public async Task<ActionResult<List<Interviewee>>> GetInterviewees()
        {
            return await _context.Interviewees.ToListAsync();
        }

        // GET: api/Audios
        [HttpGet("audios")]
        public async Task<ActionResult<IEnumerable<Interview>>> GetAudioInterviews()
        {
            return await _context.Interviews.Where(a => (a.InterviewStatusId == 3) || (a.InterviewStatusId == 4) || (a.InterviewStatusId == 7) || (a.InterviewStatusId == 9))
                .Include("Interviewee")
                .Include("InterviewStatus")
                .ToListAsync();
        }

        // DELETE: api/Interview/updatestatus
        [HttpDelete("updatestatus/{id}/{statusId}")]
        public async Task<IActionResult> UpdateStatus(Guid id, int statusId)
        {
            var interview = await _context.Interviews.FindAsync(id);
            if (interview == null)
            {
                return NotFound();
            }

            interview.InterviewStatusId = statusId;
            _context.Entry(interview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!InterviewExists(id))
                if (!InterviewExists(interview.Id))
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
    }
}
