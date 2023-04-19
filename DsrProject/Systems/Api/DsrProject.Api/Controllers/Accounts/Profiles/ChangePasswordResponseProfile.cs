using AutoMapper;
using DsrProject.Api.Controllers.Accounts.Models;
using DsrProject.Services.UserAccount.Models;

namespace DsrProject.Api.Controllers.Accounts.Profiles
{
    public class ChangePasswordResponseProfile : Profile
    {
        public ChangePasswordResponseProfile()
        {
            CreateMap<ChangePasswordModel, ChangePasswordResponse>();
        }
    }
}
