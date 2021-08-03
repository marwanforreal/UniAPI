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

        public bool CourseExists(int courseId)
        {
            var result = _context.Courses
                .Any(p => p.Id == courseId);

            return result;
        }

        public bool StudentExists(int studentId)
        {
            var result = _context.Students.Any(p => p.Id == studentId);

            return result;
        }

        public bool LecturerExists(int lecturerId)
        {
            var result = _context.Lecturers.Any(p => p.Id == lecturerId);

            return result;
        }

        public bool ClassRoomExists(int classRoomId)
        {
            var result = _context.ClassRooms.Any(p => p.Id == classRoomId);

            return result;
        }

        public ICollection<Course> GetAllCourses()
        {
            var result = _context.Courses
                .Select(P => P)
                .ToList();

            return result;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var result = _context.Students
                .Select(P => P)
                .ToList();

            return result;
        }

        public Course GetCourseById(int courseId, bool includeStudents)
        {
            if (!includeStudents)
            {
                var result = _context.Courses
                    .SingleOrDefault(p => p.Id == courseId);

                return result;
            }

            else
            {
                var result = _context.Courses
                    .Include(P => P.Students)
                    .SingleOrDefault(p => p.Id == courseId);

                return result;
            }
        }


        public IEnumerable<Course> GetCoursesByStudent(int studentId)
        {
            var result = _context.Students
                .Where(p => p.Id == studentId)
                .SelectMany(p => p.EnrolledCourses)
                .ToList();

            if(result.Count > 0)
                return result;

            return null; 
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

        public void AddNewCourse(Course course)
        {
            _context.Courses.Add(course);
        }

        public void AddNewCourseForStudent(int studentId, Course course)
        {
            var student = _context.Students.Include(p => p.EnrolledCourses).SingleOrDefault(p => p.Id == 1);

            student.EnrolledCourses.Add(course);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
