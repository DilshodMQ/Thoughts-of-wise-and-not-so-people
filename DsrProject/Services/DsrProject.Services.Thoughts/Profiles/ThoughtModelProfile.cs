﻿using AutoMapper;
using DsrProject.Context.Entities;

namespace DsrProject.Services.Thoughts.Profiles
{
    public class ThoughtModelProfile : Profile
    {
        public ThoughtModelProfile()
        {
            CreateMap<Thought, ThoughtModel>()
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Title));
        }
    }
}
