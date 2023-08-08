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
    public class InterviewerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InterviewerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Interviewer
        [HttpGet]
        public async Task<ActionResult<List<Interviewer>>> GetInterviewers()
        {
            //return await _context.Interviewers.ToListAsync();
            return await _context.Set<Interviewer>()
                .FromSqlRaw($"select * from Interviewers")
                .ToListAsync();
            
            /*return await _context.Set<Interviewer>()
                .FromSqlInterpolated($"select * from Interviewers")
                .ToListAsync();
            */
        }

        // GET: api/Interviewer/email
        [HttpGet("{email}")]
        public async Task<ActionResult<Interviewer>> GetInterviewer(string email)
        {
            var interviewer = await _context.Interviewers.FindAsync(email); //.Where(e => e.UserName == email).FirstOrDefaultAsync();

            if (interviewer == null)
            {
                return NotFound();
            }

            return Ok((Interviewer)interviewer);
        }

        private bool InterviewerExists(string email)
        {
            return _context.Interviewers.Any(e => e.Email == email);
        }

    }
}
