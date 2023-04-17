using FluentValidation;

namespace DsrProject.Services.UserAccount
{
    public class RegisterUserAccountModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
   
}