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
    public class InterviewStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InterviewStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InterviewStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterviewStatus>>> GetInterviewsStatus()
        {
            return await _context.InterviewsStatus.ToListAsync();
        }

        // GET: api/InterviewStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InterviewStatus>> GetInterviewStatus(int id)
        {
            var interviewStatus = await _context.InterviewsStatus.FindAsync(id);

            if (interviewStatus == null)
            {
                return NotFound();
            }

            return interviewStatus;
        }


        private bool InterviewStatusExists(int id)
        {
            return _context.InterviewsStatus.Any(e => e.Id == id);
        }
    }
}
