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
    public class MemberTablesController : ControllerBase
    {
        private readonly DataContext _context;

        public MemberTablesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MemberTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberTable>>> GetMemberTable()
        {
          if (_context.MemberTable == null)
          {
              return NotFound();
          }
            return await _context.MemberTable.ToListAsync();
        }

        // GET: api/MemberTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberTable>> GetMemberTable(int id)
        {
          if (_context.MemberTable == null)
          {
              return NotFound();
          }
            var memberTable = await _context.MemberTable.FindAsync(id);

            if (memberTable == null)
            {
                return NotFound();
            }

            return memberTable;
        }

        // PUT: api/MemberTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberTable(int id, MemberTable memberTable)
        {
            if (id != memberTable.memberid)
            {
                return BadRequest();
            }

            _context.Entry(memberTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberTableExists(id))
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

        // POST: api/MemberTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MemberTable>> PostMemberTable(MemberTable memberTable)
        {
          if (_context.MemberTable == null)
          {
              return Problem("Entity set 'DataContext.MemberTable'  is null.");
          }
            _context.MemberTable.Add(memberTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemberTable", new { id = memberTable.memberid }, memberTable);
        }

        // DELETE: api/MemberTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemberTable(int id)
        {
            if (_context.MemberTable == null)
            {
                return NotFound();
            }
            var memberTable = await _context.MemberTable.FindAsync(id);
            if (memberTable == null)
            {
                return NotFound();
            }

            _context.MemberTable.Remove(memberTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MemberTableExists(int id)
        {
            return (_context.MemberTable?.Any(e => e.memberid == id)).GetValueOrDefault();
        }
    }
}
