using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyRowi.Models
{
    public class Groupe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
