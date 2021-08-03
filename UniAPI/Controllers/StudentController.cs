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
        private readonly IStudentInfoRepository _studentInfoRepository;

        private readonly ICourseInfoRepository _courseInfoRepository;

        private readonly IMapper _mapper;
        public StudentController(IStudentInfoRepository studentInfoRepository,ICourseInfoRepository courseInfoRepository ,IMapper mapper)
        {
            _studentInfoRepository = studentInfoRepository ?? throw new ArgumentNullException(nameof(studentInfoRepository));

            _courseInfoRepository = courseInfoRepository ?? throw new ArgumentNullException(nameof(studentInfoRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<List<StudentWithoutCoursesDto>> GetAllStudents()
        {
            var studentEntities = _studentInfoRepository.GetAllStudents();

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
            var studentsInCourse = _studentInfoRepository.GetStudentsByCourse(courseId);

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
            if (!_studentInfoRepository.StudentExists(studentId))
            {
                return NotFound(); 
            }

            var studentEntity = _studentInfoRepository.GetStudentById(studentId, includeCourses);

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

        [HttpPost]
        public ActionResult AddNewStudent(StudentForCreationDto newStudent)
        {
            if (_studentInfoRepository.EmailExist(newStudent.Email))
            {
                ModelState.AddModelError("Email","Email already exists");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStudentMapped = _mapper.Map<Entities.Student>(newStudent); 

            _studentInfoRepository.AddNewStudent(newStudentMapped);

            _studentInfoRepository.Save();

            return NoContent();
        }

        [HttpPut("{studentId}")]
        public ActionResult AddCoursesForStudent(int studentId, int courseId)
        {
            var course = _courseInfoRepository.GetCourseById(courseId, false); 

            _studentInfoRepository.AddNewCourseForStudent(studentId, course);

            _studentInfoRepository.Save();

            return NoContent();
        }
    }
}
