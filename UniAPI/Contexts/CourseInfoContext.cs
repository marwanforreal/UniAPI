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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    Name = "Marwan",
                    Email = "marwan@terkwaz.com"
                }
            );

            modelBuilder.Entity<Lecturer>().HasData(

                new Lecturer()
                {
                    Id = 2,
                    Name = "Ahmed",
                    Email = "Ahmed@terkwaz.com"
                }
            );

            modelBuilder.Entity<ClassRoom>().HasData(

                new ClassRoom()
                {
                    Id = 3,
                    Name = "IT108",
                    Address = "Third Floor"
                }
            );

            modelBuilder.Entity<Course>().HasData(

                new Course()
                {
                    Id = 4,
                    Name = "Introduction To Computer Science",
                    DateTime = new DateTime(2021,10,15,15,15,15),
                    ClassRoomId = 3,
                }
                    );

            modelBuilder.Entity<Student>()
                .HasMany(p => p.EnrolledCourses)
                .WithMany(t => t.Students).UsingEntity<Dictionary<string, object>>("CourseStudent",
                    r => r.HasOne<Course>().WithMany(),
                    l => l.HasOne<Student>().WithMany(),

                    je =>
                    {
                        je.HasKey("EnrolledCoursesId", "StudentsId");

                        je.HasData(
                            new {EnrolledCoursesId = 4, StudentsId = 1}
                        );
                    });

            base.OnModelCreating(modelBuilder);
        }
    }
}
