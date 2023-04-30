using DsrProject.Context.Entities;
using DsrProject.Services.Settings;
using DsrProject.Services.UserAccount;
using DsrProject.Services.UserAccount.Models;

namespace DsrProject.Services.UserAccount
{

    public interface IUserAccountService
    {
        /// <summary>
        /// Create user account
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<UserAccountModel> Create(RegisterUserAccountModel model);

        Task<ChangePasswordModel> ChangePassword(ChangePasswordModel model, User user);


    }
}