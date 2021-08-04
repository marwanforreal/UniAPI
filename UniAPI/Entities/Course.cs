using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UniAPI.Entities
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int ClassRoomId { get; set; }

        public DateTime DateTime { get; set; }

        public Lecturer Lecturer { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
