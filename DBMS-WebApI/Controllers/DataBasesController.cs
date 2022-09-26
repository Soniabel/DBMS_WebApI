using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBMS_WebApI.Entities;

namespace DBMS_WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataBasesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public DataBasesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/DataBases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataBase>>> GetDataBases()
        {
            return await _context.DataBases.ToListAsync();
        }

        // GET: api/DataBases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataBase>> GetDataBase(int id)
        {
            var dataBase = await _context.DataBases.FindAsync(id);

            if (dataBase == null)
            {
                return NotFound();
            }

            return dataBase;
        }

        // PUT: api/DataBases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataBase(int id, DataBase dataBase)
        {
            if (id != dataBase.Id)
            {
                return BadRequest();
            }

            _context.Entry(dataBase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataBaseExists(id))
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

        // POST: api/DataBases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DataBase>> PostDataBase(DataBase dataBase)
        {
            _context.DataBases.Add(dataBase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataBase", new { id = dataBase.Id }, dataBase);
        }

        // DELETE: api/DataBases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataBase(int id)
        {
            var dataBase = await _context.DataBases.FindAsync(id);
            if (dataBase == null)
            {
                return NotFound();
            }

            _context.DataBases.Remove(dataBase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataBaseExists(int id)
        {
            return _context.DataBases.Any(e => e.Id == id);
        }
    }
}
