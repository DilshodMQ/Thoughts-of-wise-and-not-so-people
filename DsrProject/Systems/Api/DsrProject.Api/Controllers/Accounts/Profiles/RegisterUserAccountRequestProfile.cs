using AutoMapper;
using DsrProject.API.Controllers.Models;
using DsrProject.Services.UserAccount;

namespace DsrProject.Api.Controllers.Accounts.Profiles
{
    public class RegisterUserAccountRequestProfile : Profile
    {
        public RegisterUserAccountRequestProfile()
        {
            CreateMap<RegisterUserAccountRequest, RegisterUserAccountModel>();
        }
    }
}
