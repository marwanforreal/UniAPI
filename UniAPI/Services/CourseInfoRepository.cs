using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IEnumerable<Course> GetAllCourse()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Course GetCourseById(int courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesByStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsByCourse(int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
