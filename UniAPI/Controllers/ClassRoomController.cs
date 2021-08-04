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
    [Route("api/classRoom")]
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
            //return Ok(_classRoomRepository.GetAllClassRooms());

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
                List<ClassRoomsWithoutCoursesAndLecturersDto> classRooms = new();

                foreach (var classRoom in classRoomEntities)
                {
                    classRooms.Add(_mapper.Map<ClassRoomsWithoutCoursesAndLecturersDto>(classRoom));
                }

                return Ok(classRooms);
            }
        }

        [HttpGet("{classRoomId}")]
        public ActionResult<ClassRoomsWithoutCoursesAndLecturersDto> GetClassRoomById(int classRoomId, bool includeCourses)
        {
            if (!_classRoomRepository.ClassRoomExists(classRoomId))
            {
                return NotFound();
            }

            var classRoomById = _classRoomRepository.GetClassRoomById(classRoomId);

            if (!includeCourses)
            {
                var mappedClassRoom = _mapper.Map<ClassRoomsWithoutCoursesAndLecturersDto>(classRoomById);

                return Ok(mappedClassRoom);
            }

            else
            {
                var mappedClassRoom = _mapper.Map<ClassRoomWithLecturersAndCoursesDto>(classRoomById);

                return Ok(mappedClassRoom);
            }
        }
    }
}
