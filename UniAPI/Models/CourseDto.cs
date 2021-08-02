using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UniAPI.Entities;

namespace UniAPI.Models
{
    public class CourseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
