using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using UniAPI.Models;
using UniAPI.Services;

namespace UniAPI.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly ICourseInfoRepository _courseInfoRepository;

        private readonly IMapper _mapper;
        public StudentController(ICourseInfoRepository courseInfoRepository, IMapper mapper)
        {
            _courseInfoRepository = courseInfoRepository ?? throw new ArgumentNullException(nameof(courseInfoRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<List<StudentWithoutCoursesDto>> GetAllStudents()
        {
            var studentEntities = _courseInfoRepository.GetAllStudents();

            List<StudentWithoutCoursesDto> students = new(); 

            foreach (var student in studentEntities)
            {
                students.Add(_mapper.Map<StudentWithoutCoursesDto>(student));
            }
            return Ok(students);
        }

        [HttpGet("{courseId}")]
        public ActionResult<List<StudentWithoutCoursesDto>> GetStudentsByCourse(int courseId)
        {
            var studentsInCourse = _courseInfoRepository.GetStudentsByCourse(courseId);

            List<StudentWithoutCoursesDto> students = new();

            foreach (var student in studentsInCourse)
            {
                students.Add(_mapper.Map<StudentWithoutCoursesDto>(student));
            }

            return Ok(students);
        }

        [HttpGet("getById/{studentId}")]
        public ActionResult GetStudentById(int studentId, bool includeCourses=false)
        {
            if (!_courseInfoRepository.StudentExists(studentId))
            {
                return NotFound(); 
            }

            var studentEntity = _courseInfoRepository.GetStudentById(studentId, includeCourses);

            if (!includeCourses)
            {
                var mappedStudent = _mapper.Map<StudentWithoutCoursesDto>(studentEntity);

                return Ok(mappedStudent);
            }
            else
            {
                var mappedStudent = _mapper.Map<StudentWithCoursesDto>(studentEntity);

                return Ok(mappedStudent);
            }
        }

        [HttpPut("{studentId}")]
        public ActionResult AddCoursesForStudent(int studentId, int courseId)
        {
            var course = _courseInfoRepository.GetCourseById(courseId, false); 

            _courseInfoRepository.AddNewCourseForStudent(studentId, course);

            _courseInfoRepository.Save();

            return NoContent();
        }
    }
}
