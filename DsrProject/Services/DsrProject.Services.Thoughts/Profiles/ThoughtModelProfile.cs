using AutoMapper;
using DsrProject.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsrProject.Services.Thoughts.Profiles
{
    public class ThoughtModelProfile : Profile
    {
        public ThoughtModelProfile()
        {
            CreateMap<Thought, ThoughtModel>()
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
        }
    }
}
