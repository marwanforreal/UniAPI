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
                .Select(p => p)
                .Include(p=>p.Lecturer)
                .ToList();

            return result;
        }


        public Course GetCourseById(int courseId, bool includeStudents)
        {
            if (!includeStudents)
            {
                var result = _context.Courses
                    .Include(p=>p.Lecturer)
                    .SingleOrDefault(p => p.Id == courseId);

                return result;
            }

            else
            {
                var result = _context.Courses
                    .Include(P => P.Students)
                    .Include(p=>p.Lecturer)
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

        public void UpdateCourseLecturer(int lecturerId, int courseId)
        {
            var course = _context.Courses.Find(courseId);

            var lecturer = _context.Lecturers.Find(lecturerId);

            lecturer.CourseId = courseId; 
        }


        public void AddNewCourse(Course course)
        {
            _context.Courses.Add(course);
        }


        public void deleteCourse(int courseId)
        {
            var courseToDelete = _context.Courses.Find(courseId);

            _context.Remove(courseToDelete);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
