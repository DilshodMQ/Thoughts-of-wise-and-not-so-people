using AutoMapper;
using DsrProject.Context.Entities;
using DsrProject.Services.Categories;

namespace DsrProject.Services.Categories.Profiles
{
    public class AddCategoryModelProfile : Profile
    {
        public AddCategoryModelProfile()
        {
            CreateMap<AddCategoryModel, Category>();
        }
    }
}
