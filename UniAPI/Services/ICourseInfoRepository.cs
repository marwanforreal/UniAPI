using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAPI.Entities;

namespace UniAPI.Services
{
    public interface ICourseInfoRepository
    {
        IEnumerable<Course> GetAllCourse();

        Course GetCourseById(int courseId);

        IEnumerable<Course> GetCoursesByStudent(int studentId);

        IEnumerable<Student> GetAllStudents();

        Student GetStudentById(int studentId);

        IEnumerable<Student> GetStudentsByCourse(int courseId);
    }
}
