using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniAPI.Entities
{
    public class ClassRoom
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        private ICollection<Course> CoursesTakingPlace { get; set; }
    }
}
