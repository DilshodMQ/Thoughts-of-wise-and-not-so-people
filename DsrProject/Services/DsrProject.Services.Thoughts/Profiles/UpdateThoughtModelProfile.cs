using AutoMapper;
using DsrProject.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsrProject.Services.Thoughts.Profiles
{
    public class UpdateThoughtModelProfile : Profile
    {
        public UpdateThoughtModelProfile()
        {
            CreateMap<UpdateThoughtModel, Thought>()
                .ForMember(d => d.Description, a => a.MapFrom(s => s.Note));
        }
    }
}
