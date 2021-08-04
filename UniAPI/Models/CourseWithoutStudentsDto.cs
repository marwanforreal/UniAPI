using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UniAPI.Entities;

namespace UniAPI.Models
{
    public class CourseWithoutStudentsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ClassRoomId { get; set; }

        public Lecturer Lecturer { get; set; } 

        public DateTime DateTime { get; set; }

    }
}
