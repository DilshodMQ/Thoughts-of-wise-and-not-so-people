using AutoMapper;
using DsrProject.API.Controllers.Models;
using DsrProject.Services.Thoughts;

namespace DsrProject.Api.Controllers.Thoughts.Profiles
{
    public class AddThoughtRequestProfile : Profile
    {
        public AddThoughtRequestProfile()
        {
            CreateMap<AddThoughtRequest, AddThoughtModel>()
                .ForMember(d => d.Note, a => a.MapFrom(s => s.Description));

        }
    }
}
