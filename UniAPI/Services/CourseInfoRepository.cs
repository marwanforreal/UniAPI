using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniAPI.Contexts;
using UniAPI.Entities;

namespace UniAPI.Services
{
    public class CourseInfoRepository : ICourseInfoRepository
    {
        private readonly CourseInfoContext _context;

        public CourseInfoRepository(CourseInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }
        public ICollection<Course> GetAllCourses()
        {
            var result = _context.Courses.Select(P => P).ToList();

            return result;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var result = _context.Students.Select(P => P).ToList();

            return result;
        }

        public Course GetCourseById(int courseId)
        {
            var result = _context.Courses.SingleOrDefault(p => p.Id == courseId);

            return result;
        }

        public IEnumerable<Course> GetCoursesByStudent(int studentId)
        {
            var result = _context.Courses.Include(p => p.Students).ToList();

            return result;
        }

        public Student GetStudentById(int studentId)
        {
            var result = _context.Students.SingleOrDefault(P => P.Id == studentId);

            return result;
        }

        public IEnumerable<Student> GetStudentsByCourse(int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
