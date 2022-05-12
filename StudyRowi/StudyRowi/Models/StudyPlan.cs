using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRowi.Models
{
    public class StudyPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string Discipline { get; set; }
        public int Semestr { get; set; }
        public int StudyTime { get; set; }
        public string FormExam { get; set; }

        public ICollection<StudyJournal> StudyJournal { get; set; } = new List<StudyJournal>();

    }
}
