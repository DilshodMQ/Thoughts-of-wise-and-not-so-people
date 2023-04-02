using AutoMapper;
using DsrProject.API.Controllers.Models;
using DsrProject.Services.Categories;

namespace DsrProject.Api.Controllers.Categories.Profiles
{
    public class CategoryResponseProfile : Profile
    {
        public CategoryResponseProfile()
        {
            CreateMap<CategoryModel, CategoryResponse>();
        }
    }
}
