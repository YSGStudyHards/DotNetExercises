using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperExercise
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonInfo, PersonInfoDto>();
        }
    }
}
