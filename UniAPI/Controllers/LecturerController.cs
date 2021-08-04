using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniAPI.Models;
using UniAPI.Services;

namespace UniAPI.Controllers
{
    [ApiController]
    [Route("lecturer")]
    public class LecturerController : ControllerBase
    {
        private readonly ILecturerInfoRepository _lecturerInfoRepository;
        private readonly ICourseInfoRepository _courseInfoRepository;
        private readonly IStudentInfoRepository _studentInfoRepository;
        private readonly IMapper _mapper;

        public LecturerController(ILecturerInfoRepository lecturerInfoRepository, 
            ICourseInfoRepository courseInfoRepository, 
            IStudentInfoRepository studentInfoRepository,
            IMapper mapper)
        {
            _lecturerInfoRepository =
                lecturerInfoRepository ?? throw new ArgumentNullException(nameof(lecturerInfoRepository));
            _courseInfoRepository =
                courseInfoRepository ?? throw new ArgumentNullException(nameof(courseInfoRepository));
            _studentInfoRepository =
                studentInfoRepository ?? throw new ArgumentNullException(nameof(studentInfoRepository));
            _mapper = 
                mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult GetAllLecturers()
        {
            var result =_lecturerInfoRepository.getAllLecturers();

            return Ok(result); 
        }

        [HttpPost]
        public ActionResult AddLecturer(LecturerForCreationDto newLecturer)
        {
            if (_lecturerInfoRepository.EmailExist(newLecturer.Email))
            {
                ModelState.AddModelError("Email", "Email already exists");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_courseInfoRepository.CourseExists(newLecturer.CourseId))
            {
                return NotFound();
            }


            var lecturerEntity = _mapper.Map<Entities.Lecturer>(newLecturer); 

            _lecturerInfoRepository.AddNewLecturer(lecturerEntity);

            _lecturerInfoRepository.Save();

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteLecturerById(int lecturerId)
        {
            if (!_lecturerInfoRepository.LecturerExists(lecturerId))
            {
                return NotFound();
            }

            _lecturerInfoRepository.DeleteLecturer(lecturerId);

            _lecturerInfoRepository.Save();

            return NoContent();
        }
    }
}
