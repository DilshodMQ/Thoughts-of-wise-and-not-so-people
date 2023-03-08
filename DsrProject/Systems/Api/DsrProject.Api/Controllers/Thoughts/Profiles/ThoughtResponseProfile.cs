using AutoMapper;
using DsrProject.API.Controllers.Models;
using DsrProject.Services.Thoughts;

namespace DsrProject.Api.Controllers.Thoughts.Profiles
{
    public class ThoughtResponseProfile : Profile
    {
        public ThoughtResponseProfile()
        {
            CreateMap<ThoughtModel, ThoughtResponse>()
                .ForMember(d => d.Description, a => a.MapFrom(s => s.Note));
        }
    }
}
