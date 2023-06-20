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
    public class StaffTablesController : ControllerBase
    {
        private readonly DataContext _context;

        public StaffTablesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/StaffTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffTable>>> GetStaffTable()
        {
          if (_context.StaffTable == null)
          {
              return NotFound();
          }
            return await _context.StaffTable.ToListAsync();
        }

        // GET: api/StaffTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffTable>> GetStaffTable(int id)
        {
          if (_context.StaffTable == null)
          {
              return NotFound();
          }
            var staffTable = await _context.StaffTable.FindAsync(id);

            if (staffTable == null)
            {
                return NotFound();
            }

            return staffTable;
        }

        // PUT: api/StaffTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffTable(int id, StaffTable staffTable)
        {
            if (id != staffTable.staffid)
            {
                return BadRequest();
            }

            _context.Entry(staffTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffTableExists(id))
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

        // POST: api/StaffTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StaffTable>> PostStaffTable(StaffTable staffTable)
        {
          if (_context.StaffTable == null)
          {
              return Problem("Entity set 'DataContext.StaffTable'  is null.");
          }
            _context.StaffTable.Add(staffTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaffTable", new { id = staffTable.staffid }, staffTable);
        }

        // DELETE: api/StaffTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffTable(int id)
        {
            if (_context.StaffTable == null)
            {
                return NotFound();
            }
            var staffTable = await _context.StaffTable.FindAsync(id);
            if (staffTable == null)
            {
                return NotFound();
            }

            _context.StaffTable.Remove(staffTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffTableExists(int id)
        {
            return (_context.StaffTable?.Any(e => e.staffid == id)).GetValueOrDefault();
        }
    }
}
