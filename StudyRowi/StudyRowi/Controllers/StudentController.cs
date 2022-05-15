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
    public class StudentsController : ControllerBase
    {
        private readonly StudyContext _context;
        public StudentsController(StudyContext context) => _context = context; 

        // Get: /api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
           return _context.Students;
        }

        // Get: /api/students/n
         [HttpGet("{id}")]
        public ActionResult<Student> GetStudentItem(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();
            return student;
        }

        // Post: /api/students
        [HttpPost]
        public ActionResult<Student> PostStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return CreatedAtAction(nameof(this.GetStudentItem), new Student { Id = student.Id }, student);
        }

         // Put: /api/students/n
        [HttpPut("{id}")]
        public ActionResult PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // Delete: /api/students/n
        [HttpDelete("{id}")]
        public ActionResult<Student> DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();
            _context.Students.Remove(student);
            _context.SaveChanges();

            return student;
        }
    }
}