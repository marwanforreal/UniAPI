using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAPI.Entities;

namespace UniAPI.Services
{
    public interface ICourseInfoRepository
    {
        bool CourseExists(int courseId);
        ICollection<Course> GetAllCourses();

        Course GetCourseById(int courseId, bool includeStudents);

        IEnumerable<Course> GetCoursesByStudent(int studentId);

        void AddNewCourse(Course course);

        void UpdateCourseLecturer(int lecturerId, int courseId);

        void deleteCourse(int courseId);

        void Save();

        void UpdateCourseClassRoom(int classRoomId, int courseId);

        public bool ClassRoomExists(int classRoomId);
    }
}
