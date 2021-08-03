using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAPI.Entities;

namespace UniAPI.Services
{
    public interface IStudentInfoRepository
    {
        bool StudentExists(int studentId);

        bool EmailExist(string email);

        IEnumerable<Student> GetAllStudents();

        Student GetStudentById(int studentId, bool includeCourses);

        IEnumerable<Student> GetStudentsByCourse(int courseId);

        void AddNewCourseForStudent(int studentId, Course course);

        void AddNewStudent(Student student);

        void Save();
    }
}
