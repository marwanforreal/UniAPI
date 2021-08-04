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
        public ActionResult<IEnumerable<ClassRoomViewDto>> GetAllClassRooms()
        {
            //return Ok(_classRoomRepository.GetAllClassRooms());

            var classRoomEntities = _classRoomRepository.GetAllClassRooms(); 

            List<ClassRoomViewDto> classRooms = new();

            foreach (var classRoom in classRoomEntities)
            {
                classRooms.Add(_mapper.Map<ClassRoomViewDto>(classRoom));
            }

            return Ok(classRooms);
        }
    }
}
