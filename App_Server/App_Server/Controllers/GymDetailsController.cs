using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace App_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public GymDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GymDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymDetails>>> GetGymDetails()
        {
          if (_context.GymDetails == null)
          {
              return NotFound();
          }
            return await _context.GymDetails.ToListAsync();
        }

        // GET: api/GymDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GymDetails>> GetGymDetails(string id)
        {
          if (_context.GymDetails == null)
          {
              return NotFound();
          }
            var gymDetails = await _context.GymDetails.FindAsync(id);

            if (gymDetails == null)
            {
                return NotFound();
            }

            return gymDetails;
        }

        // PUT: api/GymDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGymDetails(string id, GymDetails gymDetails)
        {
            if (id != gymDetails.GymEmailID)
            {
                return BadRequest();
            }

            _context.Entry(gymDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GymDetailsExists(id))
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

        // POST: api/GymDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GymDetails>> PostGymDetails(GymDetails gymDetails)
        {
          if (_context.GymDetails == null)
          {
              return Problem("Entity set 'DataContext.GymDetails'  is null.");
          }
            _context.GymDetails.Add(gymDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GymDetailsExists(gymDetails.GymEmailID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGymDetails", new { id = gymDetails.GymEmailID }, gymDetails);
        }

        // DELETE: api/GymDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGymDetails(string id)
        {
            if (_context.GymDetails == null)
            {
                return NotFound();
            }
            var gymDetails = await _context.GymDetails.FindAsync(id);
            if (gymDetails == null)
            {
                return NotFound();
            }

            _context.GymDetails.Remove(gymDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GymDetailsExists(string id)
        {
            return (_context.GymDetails?.Any(e => e.GymEmailID == id)).GetValueOrDefault();
        }
    }
}
