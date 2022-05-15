using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using StudyRowi.Models;

namespace StudyRowi.Controllers    
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyJournalController : ControllerBase
    {
        private readonly StudyContext _context;
        public StudyJournalController(StudyContext context) => _context = context; 

        // Get: /api/studyJournals
        [HttpGet]
        public ActionResult<IEnumerable<StudyJournal>> GetStudyJournals()
        {
            return _context.StudyJournals;
        }

        // Get: /api/studyJournals/n
         [HttpGet("{id}")]
        public ActionResult<StudyJournal> GetStudyJournalItem(int id)
        {
            var studyJournal = _context.StudyJournals.Find(id);
            if (studyJournal == null) return NotFound();
            return studyJournal;
        }

        // Post: /api/studyJournals
        [HttpPost]
        public ActionResult<StudyJournal> PostStudyJournal(StudyJournal studyJournal)
        {
            _context.StudyJournals.Add(studyJournal);
            _context.SaveChanges();
            return CreatedAtAction(nameof(this.GetStudyJournals), new StudyJournal { Id = studyJournal.Id }, studyJournal);
        }

         // Put: /api/studyJournals/n
        [HttpPut("{id}")]
        public ActionResult PutStudyJournal(int id, StudyJournal studyJournal)
        {
            if (id != studyJournal.Id)
            {
                return BadRequest();
            }

            _context.Entry(studyJournal).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // Delete: /api/studyJournals/n
        [HttpDelete("{id}")]
        public ActionResult<StudyJournal> DeleteStudyJournal(int id)
        {
            var studyJournal = _context.StudyJournals.Find(id);
            if (studyJournal == null) return NotFound();
            _context.StudyJournals.Remove(studyJournal);
            _context.SaveChanges();

            return studyJournal;
        }
    }
}