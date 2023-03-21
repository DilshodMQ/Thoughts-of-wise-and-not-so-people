using DsrProject.API.Controllers.Models;
using DsrProject.Services.Categories;
using AutoMapper;

namespace DsrProject.Api.Controllers.Categories.Profiles
{
    public class UpdateCategoryRequestProfile : Profile
    {
        public UpdateCategoryRequestProfile()
        {
            CreateMap<UpdateCategoryRequest, UpdateCategoryModel>();
        }
    }
}
