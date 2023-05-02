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
    public class JournalsController : ControllerBase
    {
        private readonly TeacherBookContext _context;

        public JournalsController(TeacherBookContext context)
        {
            _context = context;
        }

        // GET: api/Journals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Journal>>> GetJournals()
        {
          if (_context.Journals == null)
          {
              return NotFound();
          }
            return await _context.Journals.
                Include(x => x.IdSubjectNavigation).
                Include(x => x.IdStudentNavigation)
                .ToListAsync();
        }

        // GET: api/Journals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Journal>> GetJournal(int id)
        {
          if (_context.Journals == null)
          {
              return NotFound();
          }
            var journal = await _context.Journals.FindAsync(id);

            if (journal == null)
            {
                return NotFound();
            }

            return journal;
        }

        // PUT: api/Journals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJournal(int id, Journal journal)
        {
            if (id != journal.IdJournal)
            {
                return BadRequest();
            }

            _context.Entry(journal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JournalExists(id))
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

        // POST: api/Journals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Journal>> PostJournal(Journal journal)
        {
          if (_context.Journals == null)
          {
              return Problem("Entity set 'TeacherBookContext.Journals'  is null.");
          }
            _context.Journals.Add(journal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJournal", new { id = journal.IdJournal }, journal);
        }

        // DELETE: api/Journals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJournal(int id)
        {
            if (_context.Journals == null)
            {
                return NotFound();
            }
            var journal = await _context.Journals.FindAsync(id);
            if (journal == null)
            {
                return NotFound();
            }

            _context.Journals.Remove(journal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JournalExists(int id)
        {
            return (_context.Journals?.Any(e => e.IdJournal == id)).GetValueOrDefault();
        }
    }
}
