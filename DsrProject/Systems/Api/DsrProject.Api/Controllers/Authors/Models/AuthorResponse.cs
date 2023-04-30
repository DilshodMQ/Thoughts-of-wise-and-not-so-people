using AutoMapper;
using DsrProject.Services.Authors;

namespace DsrProject.API.Controllers.Authors.Models
{
    public class AuthorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class AuthorResponseProfile : Profile
    {
        public AuthorResponseProfile()
        {
            CreateMap<AuthorModel, AuthorResponse>();
        }
    }
}
