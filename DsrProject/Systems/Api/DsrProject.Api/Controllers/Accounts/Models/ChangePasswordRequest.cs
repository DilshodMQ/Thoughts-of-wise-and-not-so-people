namespace DsrProject.Api.Controllers.Accounts.Models
{
    public class ChangePasswordRequest
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
