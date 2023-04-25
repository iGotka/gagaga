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
    public class TeacherHasSubjectsController : ControllerBase
    {
        private readonly TeacherBookContext _context;

        public TeacherHasSubjectsController(TeacherBookContext context)
        {
            _context = context;
        }

        // GET: api/TeacherHasSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherHasSubject>>> GetTeacherHasSubjects()
        {
          if (_context.TeacherHasSubjects == null)
          {
              return NotFound();
          }
            return await _context.TeacherHasSubjects.ToListAsync();
        }

        // GET: api/TeacherHasSubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherHasSubject>> GetTeacherHasSubject(int id)
        {
          if (_context.TeacherHasSubjects == null)
          {
              return NotFound();
          }
            var teacherHasSubject = await _context.TeacherHasSubjects.FindAsync(id);

            if (teacherHasSubject == null)
            {
                return NotFound();
            }

            return teacherHasSubject;
        }

        // PUT: api/TeacherHasSubjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacherHasSubject(int id, TeacherHasSubject teacherHasSubject)
        {
            if (id != teacherHasSubject.IdTd)
            {
                return BadRequest();
            }

            _context.Entry(teacherHasSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherHasSubjectExists(id))
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

        // POST: api/TeacherHasSubjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeacherHasSubject>> PostTeacherHasSubject(TeacherHasSubject teacherHasSubject)
        {
          if (_context.TeacherHasSubjects == null)
          {
              return Problem("Entity set 'TeacherBookContext.TeacherHasSubjects'  is null.");
          }
            _context.TeacherHasSubjects.Add(teacherHasSubject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacherHasSubject", new { id = teacherHasSubject.IdTd }, teacherHasSubject);
        }

        // DELETE: api/TeacherHasSubjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherHasSubject(int id)
        {
            if (_context.TeacherHasSubjects == null)
            {
                return NotFound();
            }
            var teacherHasSubject = await _context.TeacherHasSubjects.FindAsync(id);
            if (teacherHasSubject == null)
            {
                return NotFound();
            }

            _context.TeacherHasSubjects.Remove(teacherHasSubject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherHasSubjectExists(int id)
        {
            return (_context.TeacherHasSubjects?.Any(e => e.IdTd == id)).GetValueOrDefault();
        }
    }
}
