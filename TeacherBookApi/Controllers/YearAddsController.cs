using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeacherBookApi.Models;

namespace TeacherBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearAddsController : ControllerBase
    {
        private readonly TeacherBookContext _context;

        public YearAddsController(TeacherBookContext context)
        {
            _context = context;
        }

        // GET: api/YearAdds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YearAdd>>> GetYearAdds()
        {
          if (_context.YearAdds == null)
          {
              return NotFound();
          }
            return await _context.YearAdds.ToListAsync();
        }

        // GET: api/YearAdds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YearAdd>> GetYearAdd(int id)
        {
          if (_context.YearAdds == null)
          {
              return NotFound();
          }
            var yearAdd = await _context.YearAdds.FindAsync(id);

            if (yearAdd == null)
            {
                return NotFound();
            }

            return yearAdd;
        }

        // PUT: api/YearAdds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYearAdd(int id, YearAdd yearAdd)
        {
            if (id != yearAdd.IdYear)
            {
                return BadRequest();
            }

            _context.Entry(yearAdd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearAddExists(id))
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

        // POST: api/YearAdds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<YearAdd>> PostYearAdd(YearAdd yearAdd)
        {
          if (_context.YearAdds == null)
          {
              return Problem("Entity set 'TeacherBookContext.YearAdds'  is null.");
          }
            _context.YearAdds.Add(yearAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYearAdd", new { id = yearAdd.IdYear }, yearAdd);
        }

        // DELETE: api/YearAdds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYearAdd(int id)
        {
            if (_context.YearAdds == null)
            {
                return NotFound();
            }
            var yearAdd = await _context.YearAdds.FindAsync(id);
            if (yearAdd == null)
            {
                return NotFound();
            }

            _context.YearAdds.Remove(yearAdd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YearAddExists(int id)
        {
            return (_context.YearAdds?.Any(e => e.IdYear == id)).GetValueOrDefault();
        }
    }
}
