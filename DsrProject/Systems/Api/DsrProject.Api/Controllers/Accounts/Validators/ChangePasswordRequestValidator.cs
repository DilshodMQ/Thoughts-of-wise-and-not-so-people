using DsrProject.Api.Controllers.Accounts.Models;
using FluentValidation;

namespace DsrProject.Api.Controllers.Accounts.Validators
{
    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("NewPassword is required.");

            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage("OldPassword is required.");
        }
    }
}
