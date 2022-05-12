using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRowi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int DateReceipt { get; set; }
        public string FormStudy { get; set; }

        public int GroupeId { get; set; }
        public Groupe Groupe { get; set; }

        public ICollection<StudyJournal> StudyJournal { get; set; } = new List<StudyJournal>();
        
    }
}
