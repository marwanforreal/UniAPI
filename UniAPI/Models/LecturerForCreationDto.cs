using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniAPI.Models
{
    public class LecturerForCreationDto
    { 
        public string Name { get; set; }

        public string Email { get; set; }

        public int CourseId { get; set; }
    }
}
