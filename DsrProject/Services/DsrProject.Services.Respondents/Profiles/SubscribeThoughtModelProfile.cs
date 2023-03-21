using AutoMapper;
using DsrProject.Context.Entities;
using DsrProject.Services.Respondents.Models;

namespace DsrProject.Services.Respondents.Profiles
{
    public class SubscribeThoughtModelProfile : Profile
    {
        public SubscribeThoughtModelProfile()
        {
            CreateMap<SubscribeThoughtModel, ThoughtRespondent>();
        }
    }
}
