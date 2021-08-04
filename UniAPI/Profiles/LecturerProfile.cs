using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UniAPI.Models;

namespace UniAPI.Profiles
{
    public class LecturerProfile : Profile
    {
        public LecturerProfile()
        {
            CreateMap<LecturerForCreationDto, Entities.Lecturer>();
            CreateMap<Entities.Lecturer, LecturerViewDto>();
        }
    }
}
