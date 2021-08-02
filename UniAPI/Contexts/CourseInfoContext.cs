using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniAPI.Entities;

namespace UniAPI.Contexts
{
    public class CourseInfoContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Lecturer> Lecturers { get; set; }

        public DbSet<ClassRoom> ClassRooms { get; set; }

        public CourseInfoContext(DbContextOptions<CourseInfoContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

    }
}
