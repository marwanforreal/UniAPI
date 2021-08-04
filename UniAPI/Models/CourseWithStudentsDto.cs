using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniAPI.Models
{
    public class CourseWithStudentsDto
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public int ClassRoomId { get; set; }

        public DateTime DateTime { get; set; }

        public LecturerWithoutCourseDto Lecturer { get; set; }
        public ICollection<StudentWithoutCoursesDto> Students { get; set; } 
            = new List<StudentWithoutCoursesDto>();
    }
}
