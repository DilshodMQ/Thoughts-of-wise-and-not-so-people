using AutoMapper;
using DsrProject.API.Controllers.Models;
using DsrProject.Services.Thoughts;

namespace DsrProject.Api.Controllers.Thoughts.Profiles
{
    public class UpdateThoughtRequestProfile : Profile
    {
        public UpdateThoughtRequestProfile()
        {
            CreateMap<UpdateThoughtRequest, UpdateThoughtModel>()
                .ForMember(d => d.Note, a => a.MapFrom(s => s.Description));
        }
    }
}
