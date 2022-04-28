using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwards
{
    public class StudyJournal
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public int Grade { get; set; }

        public int StudentId { get; set; }
        public Student Students { get; set; }
        public int StudyPlanId { get; set; }
        public StudyPlan StudyPlans { get; set; }

    }
}
