using AutoMapper;
using DsrProject.Api.Controllers.Respondents.Models;
using DsrProject.Services.Respondents.Models;

namespace DsrProject.Api.Controllers.Respondents.Profiles
{
    public class AddCommentRequestProfile : Profile
    {
        public AddCommentRequestProfile()
        {
           CreateMap<AddCommentRequest, AddCommentModel>();
        }
    }
}
