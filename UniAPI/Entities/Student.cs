using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniAPI.Entities
{
    public class Student : Person
    {
        public ICollection<Course> EnrolledCourses { get; set; } = new List<Course>();
    }
}
