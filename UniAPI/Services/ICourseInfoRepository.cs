using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAPI.Entities;

namespace UniAPI.Services
{
    public interface ICourseInfoRepository
    {
        ICollection<Course> GetAllCourses();

        Course GetCourseById(int courseId, bool includeStudents);

        IEnumerable<Course> GetCoursesByStudent(int studentId);

        IEnumerable<Student> GetAllStudents();

        Student GetStudentById(int studentId, bool includeCourses);

        IEnumerable<Student> GetStudentsByCourse(int courseId);

        bool CourseExists(int courseId);

        bool StudentExists(int studentId);

        bool LecturerExists(int lecturerId);

        public bool ClassRoomExists(int classRoomId);

        void AddNewCourse(Course course);

        void AddNewCourseForStudent(int studentId, Course course);

        void Save();
    }
}
