using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UniAPI.Models;

namespace UniAPI.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Entities.Course, CourseWithoutStudentsDto>().ReverseMap();

            CreateMap<Entities.Course, CourseWithStudentsDto>().ReverseMap();

            CreateMap<CourseForCreationDto, Entities.Course>();
        }
    }
}
