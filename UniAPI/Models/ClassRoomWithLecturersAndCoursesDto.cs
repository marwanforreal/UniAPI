using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAPI.Entities;

namespace UniAPI.Models
{
    public class ClassRoomWithLecturersAndCoursesDto
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<CourseWithoutStudentsDto> Courses { get; set; }
    }

}
