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
    [Route("students")]
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
        
    }
}
