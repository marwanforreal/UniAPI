using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniAPI.Models
{
    public class StudentWithNewCourseDto
    {
        public ICollection<CourseWithoutStudentsDto> EnrolledCourses { get; set; } =
            new List<CourseWithoutStudentsDto>();
    }
}
