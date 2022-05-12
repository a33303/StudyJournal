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
    public class GroupesController : ControllerBase
    {
        private readonly StudyContext _context;
        public GroupesController(StudyContext context) => _context = context; 

        // Get: /api/groupes
        [HttpGet]
        public ActionResult<IEnumerable<Groupe>> GetGroupes()
        {
            return _context.Groupes;
        }

        // Get: /api/groupes/n
        [HttpGet("{id}")]
        public ActionResult<Groupe> GetGroupeItem(int id)
        {
            var groupe = _context.Groupes.Find(id);
            if (groupe == null) return NotFound();
            return groupe;
        }

        // Post: /api/groupes

        [HttpPost]
        public ActionResult<Groupe> PostGroupe(Groupe groupe)
        {
            _context.Groupes.Add(groupe);
            _context.SaveChanges();
            return CreatedAtAction("GetGroupe", new Groupe { Id = groupe.Id}, groupe);
          // return 123;
        }

        // Put: /api/groupes/n
        [HttpPut("{id}")]
        public ActionResult PutGroupe(int id, Groupe groupe)
        {
            if (id != groupe.Id)
            {
                return BadRequest();
            }

            _context.Entry(groupe).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // Delete: /api/doctors/n
        [HttpDelete("{id}")]
        public ActionResult<Groupe> DeleteGroupe(int id)
        {
            var groupe = _context.Groupes.Find(id);
            if (groupe == null) return NotFound();
            _context.Groupes.Remove(groupe);
            _context.SaveChanges();

            return groupe;
        }
    }
}