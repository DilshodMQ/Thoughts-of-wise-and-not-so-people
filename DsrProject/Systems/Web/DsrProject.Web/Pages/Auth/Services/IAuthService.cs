using System.Threading.Tasks;

namespace DsrProject.Web
{
    public interface IAuthService
    {
        Task<bool> Registr(RegistrModel registrModel);
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
    }
}