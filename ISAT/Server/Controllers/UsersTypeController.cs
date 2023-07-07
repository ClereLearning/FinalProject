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
    public class UsersTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/userstype
        [HttpGet]
        public async Task<ActionResult<List<UsersType>>> GetUsersTypes()
        {
            return await _context.UsersTypes.ToListAsync();
        }

        // GET: api/userstype/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersType>> GetUsersType(int id)
        {
            var usersType = await _context.UsersTypes.FindAsync(id);

            if (usersType == null)
            {
                return NotFound();
            }

            return Ok((UsersType)usersType);
        }


        // POST: api/userstype        
        [HttpPost]
        public async Task<ActionResult<UsersType>> PostUsersType(UsersType usersType)
        {
            _context.UsersTypes.Add(usersType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserType", new { id = usersType.Id }, usersType);
        }

        // PUT: api/userstype/5        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersType(int id, UsersType usersType)
        {
            if (id != usersType.Id)
            {
                return BadRequest();
            }

            _context.Entry(usersType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTypeExists(id))
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

        // DELETE: api/userstype/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersType(int id)
        {
            var UsersType = await _context.UsersTypes.FindAsync(id);
            if (UsersType == null)
            {
                return NotFound();
            }

            _context.UsersTypes.Remove(UsersType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserTypeExists(int id)
        {
            return _context.UsersTypes.Any(e => e.Id == id);
        }
    }
}