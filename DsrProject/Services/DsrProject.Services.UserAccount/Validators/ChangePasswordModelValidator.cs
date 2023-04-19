using DsrProject.Services.UserAccount.Models;
using FluentValidation;

namespace DsrProject.Services.UserAccount.Validators
{
    public class ChangePasswordModelValidator : AbstractValidator<ChangePasswordModel>
    {
        public ChangePasswordModelValidator()
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
