using AutoMapper;
using DsrProject.Context.Entities;
using DsrProject.Services.Respondents.Models;

namespace DsrProject.Services.Respondents.Profiles
{
    public class AddCommentModelProfile :Profile
    {
        public AddCommentModelProfile()
        {
            CreateMap<AddCommentModel, Comment>();               
        }
    }
}
