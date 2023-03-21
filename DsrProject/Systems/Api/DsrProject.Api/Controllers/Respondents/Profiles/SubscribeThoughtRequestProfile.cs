using AutoMapper;
using DsrProject.Api.Controllers.Respondents.Models;
using DsrProject.Services.Respondents.Models;

namespace DsrProject.Api.Controllers.Respondents.Profiles
{
    public class SubscribeThoughtRequestProfile : Profile
    {
        public SubscribeThoughtRequestProfile()
        {
            CreateMap<SubscribeThoughtRequest, SubscribeThoughtModel>();
        }
    }
}
