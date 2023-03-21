using AutoMapper;
using DsrProject.Context.Entities;

namespace DsrProject.Services.Categories.Profiles
{
    public class UpdateCategoryModelProfile : Profile
    {
        public UpdateCategoryModelProfile()
        {
            CreateMap<UpdateCategoryModel, Category>();
        }
    }
}
