using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniAPI.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ClassRoom Room { get; set; }

        public DateTime DateTime { get; set; }

        public Lecturer Lecturer { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
