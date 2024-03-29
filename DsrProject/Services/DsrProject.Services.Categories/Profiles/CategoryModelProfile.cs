﻿using AutoMapper;
using DsrProject.Context.Entities;

namespace DsrProject.Services.Categories.Profiles
{
    public class CategoryModelProfile : Profile
    {
        public CategoryModelProfile()
        {
            CreateMap<Category, CategoryModel>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
        }
    }
}
