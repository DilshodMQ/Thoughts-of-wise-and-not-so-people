using System.ComponentModel.DataAnnotations;

namespace DsrProject.Api.Controllers.Accounts.Models
{
    public class ResetPassword
    {
        [Required]
        public string  Password { get; set; }

        [Compare("Password", ErrorMessage="The password and ConfirmPassword do not match")]
        public string  ConfirmPassword { get; set; }

        public string Token { get; set; }

        public string Email { get; set; }
    }
}
