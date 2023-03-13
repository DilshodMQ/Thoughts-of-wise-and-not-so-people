using AutoMapper;
using DsrProject.Context.Entities;
using DsrProject.Services.Respondents.Models;

namespace DsrProject.Services.Respondents.Profiles
{
    public class CommentModelProfile : Profile
    {
        public CommentModelProfile()
        {
            CreateMap<Comment, CommentModel>();
        }
    }
}
