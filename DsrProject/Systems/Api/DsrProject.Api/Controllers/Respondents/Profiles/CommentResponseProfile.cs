using AutoMapper;
using DsrProject.Api.Controllers.Respondents.Models;
using DsrProject.Services.Respondents.Models;

namespace DsrProject.Api.Controllers.Respondents.Profiles
{
    public class CommentResponseProfile : Profile
    {
        public CommentResponseProfile()
        {
            CreateMap<CommentModel, CommentResponse>();
        }
    }
}
