using AutoMapper;
using DsrProject.Context.Entities;

namespace DsrProject.Services.UserAccount.Profiles
{
    public class UserAccountModelProfile : Profile
    {
        public UserAccountModelProfile()
        {
            CreateMap<User, UserAccountModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.FullName))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
                ;
        }
    }
}
