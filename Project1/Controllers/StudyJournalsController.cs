using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hogwards;

namespace Hogwards.Spa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyJournalsController : ControllerBase
    {
        private readonly StudyContext _context;

        public StudyJournalsController(StudyContext context)
        {
            _context = context;
        }

        // GET: api/StudyJournals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudyJournal>>> GetStudyJournals()
        {
            return await _context.StudyJournals.ToListAsync();
        }

        // GET: api/StudyJournals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudyJournal>> GetStudyJournal(int id)
        {
            var studyJournal = await _context.StudyJournals.FindAsync(id);

            if (studyJournal == null)
            {
                return NotFound();
            }

            return studyJournal;
        }

        // PUT: api/StudyJournals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudyJournal(int id, StudyJournal studyJournal)
        {
            if (id != studyJournal.Id)
            {
                return BadRequest();
            }

            _context.Entry(studyJournal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudyJournalExists(id))
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

        // POST: api/StudyJournals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudyJournal>> PostStudyJournal(StudyJournal studyJournal)
        {
            _context.StudyJournals.Add(studyJournal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudyJournal", new { id = studyJournal.Id }, studyJournal);
        }

        // DELETE: api/StudyJournals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudyJournal(int id)
        {
            var studyJournal = await _context.StudyJournals.FindAsync(id);
            if (studyJournal == null)
            {
                return NotFound();
            }

            _context.StudyJournals.Remove(studyJournal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudyJournalExists(int id)
        {
            return _context.StudyJournals.Any(e => e.Id == id);
        }
    }
}
