using DsrProject.Web.Pages.Auth;
using DsrProject.Web.Pages.Auth.ForgotPwd;
using System.Threading.Tasks;

namespace DsrProject.Web
{
    public interface IAuthService
    {
        Task<bool> Registr(RegistrModel registrModel);
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();

        Task<bool> ForgotPassword(ForgotPasswordModel model);

        Task<bool> ResetForgotPassword(ResetPasswordModel resetPassword);
    }
}