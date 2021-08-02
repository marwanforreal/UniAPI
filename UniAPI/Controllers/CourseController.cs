using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniAPI.Entities;
using UniAPI.Services;

namespace UniAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseInfoRepository _courseInfoRepository;

        public CourseController(ICourseInfoRepository courseInfoRepository)
        {
            _courseInfoRepository =
                courseInfoRepository ?? throw new ArgumentNullException(nameof(courseInfoRepository));
        }


        [HttpGet]
        public ActionResult<List<Course>> GetAllCourses()
        {
            return Ok(_courseInfoRepository.GetAllCourses());
        }
    }
}
