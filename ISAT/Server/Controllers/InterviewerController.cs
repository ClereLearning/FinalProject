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
    public class InterviewerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InterviewerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Interviewer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interviewer>>> GetInterviewers()
        {   
            return await _context.Interviewers.ToListAsync();
        }

        // GET: api/Interviewer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interviewer>> GetInterviewer(string email)
        {
            var interviewers = await _context.Interviewers.FindAsync(email);

            if (interviewers == null)
            {
                return NotFound();
            }

            return interviewers;
        }

        private bool InterviewerExists(string email)
        {
            return _context.Interviewers.Any(e => e.Email == email);
        }

    }
}
