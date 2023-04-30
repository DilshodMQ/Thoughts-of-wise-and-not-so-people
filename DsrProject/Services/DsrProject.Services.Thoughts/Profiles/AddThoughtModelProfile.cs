using AutoMapper;
using DsrProject.Context.Entities;

namespace DsrProject.Services.Thoughts.Profiles
{
    public class AddThoughtModelProfile : Profile
    {
        public AddThoughtModelProfile()
        {
            CreateMap<AddThoughtModel, Thought>()
                .ForMember(d => d.Description, a => a.MapFrom(s => s.Note));
        }
    }
}
