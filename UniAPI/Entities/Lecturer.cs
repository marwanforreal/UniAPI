using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniAPI.Entities
{
    public class Lecturer : Person
    {
        public int CourseId { get; set; }
    }
}
