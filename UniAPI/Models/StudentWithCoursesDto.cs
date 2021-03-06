using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniAPI.Models
{
    public class StudentWithCoursesDto
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<CourseWithoutStudentsDto> EnrolledCourses { get; set; } =
            new List<CourseWithoutStudentsDto>();
    }
}
