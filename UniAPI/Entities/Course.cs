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

        [ForeignKey("ClassRoomId")]
        public ClassRoom Room { get; set; }

        public int ClassRoomId { get; set; }

        public DateTime DateTime { get; set; }

        [ForeignKey("LecturerId")]
        public Lecturer Lecturer { get; set; }

        public int LecturerId { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
