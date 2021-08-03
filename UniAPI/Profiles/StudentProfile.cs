using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UniAPI.Models;

namespace UniAPI.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Entities.Student, StudentWithoutCoursesDto>().ReverseMap();

            CreateMap<Entities.Student, StudentWithCoursesDto>().ReverseMap();

            CreateMap<StudentForCreationDto, Entities.Student>();
        }
    }
}
