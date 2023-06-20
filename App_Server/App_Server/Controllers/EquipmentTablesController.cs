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
    public class EquipmentTablesController : ControllerBase
    {
        private readonly DataContext _context;

        public EquipmentTablesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentTable>>> GetEquipmentTable()
        {
          if (_context.EquipmentTable == null)
          {
              return NotFound();
          }
            return await _context.EquipmentTable.ToListAsync();
        }

        // GET: api/EquipmentTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentTable>> GetEquipmentTable(int id)
        {
          if (_context.EquipmentTable == null)
          {
              return NotFound();
          }
            var equipmentTable = await _context.EquipmentTable.FindAsync(id);

            if (equipmentTable == null)
            {
                return NotFound();
            }

            return equipmentTable;
        }

        // PUT: api/EquipmentTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentTable(int id, EquipmentTable equipmentTable)
        {
            if (id != equipmentTable.EquipmentID)
            {
                return BadRequest();
            }

            _context.Entry(equipmentTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentTableExists(id))
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

        // POST: api/EquipmentTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EquipmentTable>> PostEquipmentTable(EquipmentTable equipmentTable)
        {
          if (_context.EquipmentTable == null)
          {
              return Problem("Entity set 'DataContext.EquipmentTable'  is null.");
          }
            _context.EquipmentTable.Add(equipmentTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipmentTable", new { id = equipmentTable.EquipmentID }, equipmentTable);
        }

        // DELETE: api/EquipmentTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentTable(int id)
        {
            if (_context.EquipmentTable == null)
            {
                return NotFound();
            }
            var equipmentTable = await _context.EquipmentTable.FindAsync(id);
            if (equipmentTable == null)
            {
                return NotFound();
            }

            _context.EquipmentTable.Remove(equipmentTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentTableExists(int id)
        {
            return (_context.EquipmentTable?.Any(e => e.EquipmentID == id)).GetValueOrDefault();
        }
    }
}
