using AutoMapper;
using DsrProject.API.Controllers.Models;
using DsrProject.Services.Categories;

namespace DsrProject.Api.Controllers.Categories.Profiles
{
    public class AddCategoryRequestProfile : Profile
    {
        public AddCategoryRequestProfile()
        {
            CreateMap<AddCategoryRequest, AddCategoryModel>();
               
        }
    }
}
