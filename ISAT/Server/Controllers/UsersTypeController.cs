using ISAT.Server.Data;
using ISAT.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISAT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersTypeController(ApplicationDbContext context)
        {
            _context = context;
        }
        /*
        [HttpGet]
        public async Task<ActionResult<List<UsersType>>> GetUsersTypes() 
        {
            //var user = await _context.UsersTypes.ToList<UsersType>();

                
        }
        */
    }
}
