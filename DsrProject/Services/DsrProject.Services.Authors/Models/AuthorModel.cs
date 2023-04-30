using AutoMapper;
using DsrProject.Context.Entities;

namespace DsrProject.Services.Authors
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class AuthorModelProfile : Profile
    {
        public AuthorModelProfile()
        {
            CreateMap<Author, AuthorModel>();
        }
    }
}