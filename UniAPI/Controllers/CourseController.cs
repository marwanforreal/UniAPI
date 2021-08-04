using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniAPI.Entities;
using UniAPI.Models;
using UniAPI.Services;

namespace UniAPI.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseInfoRepository _courseInfoRepository;

        private readonly IMapper _mapper;

        public CourseController(ICourseInfoRepository courseInfoRepository, IMapper imapper)
        {
            _courseInfoRepository =
                courseInfoRepository ?? throw new ArgumentNullException(nameof(courseInfoRepository));

            _mapper = imapper ?? throw new ArgumentNullException(nameof(imapper));
        }


        [HttpGet]
        public ActionResult<List<CourseWithoutStudentsDto>> GetAllCourses()
        {
            var result = _courseInfoRepository.GetAllCourses();

            List<CourseWithoutStudentsDto> listOfCourses = new();

            foreach (var course in result)
            {
                var mappedCourse = _mapper.Map<CourseWithoutStudentsDto>(course);

                listOfCourses.Add(mappedCourse);
            }

            return Ok(listOfCourses);
        }

        [HttpGet("{courseId}")]
        public ActionResult GetCourseById(int courseId, bool includeStudents = false)
        {
            if (!_courseInfoRepository.CourseExists(courseId))
            {
                return NotFound();
            }

            var courseById = _courseInfoRepository.GetCourseById(courseId, includeStudents);

            if (!includeStudents)
            {
                var mappedCourse = _mapper.Map<CourseWithoutStudentsDto>(courseById);

                return Ok(mappedCourse);
            }

            else
            {
                var mappedCourse = _mapper.Map<CourseWithStudentsDto>(courseById);

                return Ok(mappedCourse);
            }
        }

        [HttpGet("students/{studentId}")]
        public ActionResult<CourseWithoutStudentsDto> GetCourseByStudentId(int studentId)
        {
            var result = _courseInfoRepository.GetCoursesByStudent(studentId);

            if (result == null)
            {
                return NotFound();
            }

            List<CourseWithoutStudentsDto> listOfCourses = new();

            foreach (var course in result)
            {
                var mappedCourse = _mapper.Map<CourseWithoutStudentsDto>(course);

                listOfCourses.Add(mappedCourse);
            }

            return Ok(listOfCourses);
        }

        [HttpPut("{courseId}")]
        public ActionResult UpdateCourseLecturer(int courseId, int lecturerId)
        {
            if (!_courseInfoRepository.CourseExists(courseId))
            {
                return NotFound();
            }

            _courseInfoRepository.UpdateCourseLecturer(lecturerId,courseId);

            _courseInfoRepository.Save();

            return NoContent();
        }

        [HttpPost]
        public ActionResult AddNewCourse(CourseForCreationDto newCourse)
        {
            if (!_courseInfoRepository.ClassRoomExists(newCourse.ClassRoomId))
            {
                return NotFound();
            }

            var mappedCourse = _mapper.Map<Entities.Course>(newCourse); 

            _courseInfoRepository.AddNewCourse(mappedCourse);

            _courseInfoRepository.Save();

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteCourseById(int courseId)
        {
            if (!_courseInfoRepository.CourseExists(courseId))
            {
                return NotFound(); 
            }

            _courseInfoRepository.deleteCourse(courseId);

            _courseInfoRepository.Save();

            return NoContent();
        }
    }
}
