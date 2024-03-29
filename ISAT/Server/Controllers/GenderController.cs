﻿using ISAT.Server.Data;
using ISAT.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISAT.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Gender
        [HttpGet]
        public async Task<ActionResult<List<Gender>>> GetGenders()
        {
            return await _context.Genders.ToListAsync();
        }

        // GET: api/Gender/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gender>> GetGender(Guid id)
        {
            var gender = await _context.Genders.FindAsync(id);

            if (gender == null)
            {
                return NotFound();
            }

            return Ok((Gender)gender);
        }


        // POST: api/Gender                
        [HttpPost]
        public async Task<ActionResult<Gender>> PostGender(Gender gender)
        {
            _context.Genders.Add(gender);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGender", new { id = gender.Id }, gender);
        }


        // PUT: api/Gender/5        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGender(Guid id, Gender gender)
        {
            if (id != gender.Id)
            {
                return BadRequest();
            }

            _context.Entry(gender).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenderExists(id))
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

        // DELETE: api/Gender/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGender(Guid id)
        {
            var gender = await _context.Genders.FindAsync(id);
            if (gender == null)
            {
                return NotFound();
            }

            _context.Genders.Remove(gender);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenderExists(Guid id)
        {
            return _context.Genders.Any(e => e.Id == id);
        }


    }
}
