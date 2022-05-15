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
    public class StudyPlanController : ControllerBase
    {
        private readonly StudyContext _context;
        public StudyPlanController(StudyContext context) => _context = context; 

        // Get: /api/StudyPlans
        [HttpGet]
        public ActionResult<IEnumerable<StudyPlan>> GetStudyPlans()
        {
            return _context.StudyPlans;
        }

        // Get: /api/StudyPlans/n
         [HttpGet("{id}")]
        public ActionResult<StudyPlan> GetStudyPlanItem(int id)
        {
            var StudyPlan = _context.StudyPlans.Find(id);
            if (StudyPlan == null) return NotFound();
            return StudyPlan;
        }

        // Post: /api/StudyPlans
        [HttpPost]
        public ActionResult<StudyPlan> PostStudyPlan(StudyPlan StudyPlan)
        {
            _context.StudyPlans.Add(StudyPlan);
            _context.SaveChanges();
            return CreatedAtAction(nameof(this.GetStudyPlanItem), new StudyPlan { Id = StudyPlan.Id }, StudyPlan);
        }

         // Put: /api/StudyPlans/n
        [HttpPut("{id}")]
        public ActionResult PutStudyPlan(int id, StudyPlan StudyPlan)
        {
            if (id != StudyPlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(StudyPlan).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // Delete: /api/StudyPlans/n
        [HttpDelete("{id}")]
        public ActionResult<StudyPlan> DeleteStudyPlan(int id)
        {
            var StudyPlan = _context.StudyPlans.Find(id);
            if (StudyPlan == null) return NotFound();
            _context.StudyPlans.Remove(StudyPlan);
            _context.SaveChanges();

            return StudyPlan;
        }
    }
}