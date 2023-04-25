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
    public class FormTimesController : ControllerBase
    {
        private readonly TeacherBookContext _context;

        public FormTimesController(TeacherBookContext context)
        {
            _context = context;
        }

        // GET: api/FormTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormTime>>> GetFormTimes()
        {
          if (_context.FormTimes == null)
          {
              return NotFound();
          }
            return await _context.FormTimes.ToListAsync();
        }

        // GET: api/FormTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormTime>> GetFormTime(int id)
        {
          if (_context.FormTimes == null)
          {
              return NotFound();
          }
            var formTime = await _context.FormTimes.FindAsync(id);

            if (formTime == null)
            {
                return NotFound();
            }

            return formTime;
        }

        // PUT: api/FormTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormTime(int id, FormTime formTime)
        {
            if (id != formTime.Id)
            {
                return BadRequest();
            }

            _context.Entry(formTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormTimeExists(id))
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

        // POST: api/FormTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormTime>> PostFormTime(FormTime formTime)
        {
          if (_context.FormTimes == null)
          {
              return Problem("Entity set 'TeacherBookContext.FormTimes'  is null.");
          }
            _context.FormTimes.Add(formTime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormTime", new { id = formTime.Id }, formTime);
        }

        // DELETE: api/FormTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormTime(int id)
        {
            if (_context.FormTimes == null)
            {
                return NotFound();
            }
            var formTime = await _context.FormTimes.FindAsync(id);
            if (formTime == null)
            {
                return NotFound();
            }

            _context.FormTimes.Remove(formTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormTimeExists(int id)
        {
            return (_context.FormTimes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
