using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniAPI.Models
{
    public class CourseForCreationDto
    {
        public string Name { get; set; }

        public int ClassRoomId { get; set; }

        public DateTime DateTime { get; set; }

        public int LecturerId { get; set; }
    }
}
