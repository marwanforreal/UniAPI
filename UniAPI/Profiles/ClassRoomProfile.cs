using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UniAPI.Models;

namespace UniAPI.Profiles
{
    public class ClassRoomProfile : Profile
    {
        public ClassRoomProfile()
        {
            CreateMap<Entities.ClassRoom, ClassRoomWithLecturersAndCoursesDto>();

            CreateMap<Entities.ClassRoom, ClassRoomsWithoutCoursesAndLecturersDto>().ReverseMap();
        }
    }
}
