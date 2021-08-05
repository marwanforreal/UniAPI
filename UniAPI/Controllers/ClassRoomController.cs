using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniAPI.Entities;
using UniAPI.Models;
using UniAPI.Services;

namespace UniAPI.Controllers
{
    [ApiController]
    [Route("classRoom")]
    public class ClassRoomController : ControllerBase
    {
        private readonly IClassRoomInfoRepository _classRoomRepository;

        private readonly IMapper _mapper;

        public ClassRoomController(IClassRoomInfoRepository classRoomInfoRepository, IMapper mapper)
        {
            _classRoomRepository = classRoomInfoRepository ?? throw new ArgumentNullException();

            _mapper = mapper ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClassRoomWithLecturersAndCoursesDto>> GetAllClassRooms(
            bool includeLecturersAndCourses = false)
        {
            var classRoomEntities = _classRoomRepository.GetAllClassRooms();

            if (includeLecturersAndCourses)
            {
                List<ClassRoomWithLecturersAndCoursesDto> classRooms = new();

                foreach (var classRoom in classRoomEntities)
                {
                    classRooms.Add(_mapper.Map<ClassRoomWithLecturersAndCoursesDto>(classRoom));
                }

                return Ok(classRooms);

            }
            else
            {
                List<ClassRoomWithoutCoursesAndLecturersDto> classRooms = new();

                foreach (var classRoom in classRoomEntities)
                {
                    classRooms.Add(_mapper.Map<ClassRoomWithoutCoursesAndLecturersDto>(classRoom));
                }

                return Ok(classRooms);
            }
        }

        [HttpGet("{classRoomId}")]
        public ActionResult<ClassRoomWithoutCoursesAndLecturersDto> GetClassRoomById(int classRoomId, bool includeCourses)
        {
            if (!_classRoomRepository.ClassRoomExists(classRoomId))
            {
                return NotFound();
            }

            var classRoomById = _classRoomRepository.GetClassRoomById(classRoomId);

            if (!includeCourses)
            {
                var mappedClassRoom = _mapper.Map<ClassRoomWithoutCoursesAndLecturersDto>(classRoomById);

                return Ok(mappedClassRoom);
            }

            else
            {
                var mappedClassRoom = _mapper.Map<ClassRoomWithLecturersAndCoursesDto>(classRoomById);

                return Ok(mappedClassRoom);
            }
        }

        [HttpPost]
        public ActionResult AddNewClassRoom(ClassRoomForCreationDto classRoom)
        {
            if (_classRoomRepository.ClassRoomExists(classRoom.Name))
            {
                ModelState.AddModelError("Name","Name Already Registered");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classRoomMapped = _mapper.Map<Entities.ClassRoom>(classRoom);

            _classRoomRepository.AddNewClassRoom(classRoomMapped);

            _classRoomRepository.Save();

            return NoContent();
        }
    }
}
