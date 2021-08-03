using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniAPI.Contexts;
using UniAPI.Entities;

namespace UniAPI.Services
{
    public class StudentInfoRepository : IStudentInfoRepository
    {

        private readonly CourseInfoContext _context;

        public StudentInfoRepository(CourseInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool StudentExists(int studentId)
        {
            var result = _context.Students.Any(p => p.Id == studentId);

            return result;
        }

        public bool EmailExist(string email)
        {
            var result = _context.Students.Any(p => p.Email == email);

            return result;
        }


        public void AddNewCourseForStudent(int studentId, Course course)
        {
            var student = _context.Students.Include(p => p.EnrolledCourses).SingleOrDefault(p => p.Id == studentId);

            student.EnrolledCourses.Add(course);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var result = _context.Students
                .Select(P => P)
                .ToList();

            return result;
        }

        public Student GetStudentById(int studentId, bool includeCourses)
        {
            if (!includeCourses)
            {
                var result = _context.Students
                    .SingleOrDefault(P => P.Id == studentId);

                return result;
            }
            else
            {
                var result = _context.Students
                    .Include(p => p.EnrolledCourses)
                    .SingleOrDefault(p => p.Id == studentId);

                return result;
            }
        }

        public IEnumerable<Student> GetStudentsByCourse(int courseId)
        {
            var result = _context.Courses
                .Where(P => P.Id == courseId)
                .SelectMany(p => p.Students)
                .ToList();

            return result;
        }

        public void AddNewStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
