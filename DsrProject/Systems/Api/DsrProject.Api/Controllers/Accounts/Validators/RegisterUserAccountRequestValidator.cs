using DsrProject.API.Controllers.Models;
using FluentValidation;

namespace DsrProject.Api.Controllers.Accounts.Validators
{
    public class RegisterUserAccountRequestValidator : AbstractValidator<RegisterUserAccountRequest>
    {
            public RegisterUserAccountRequestValidator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("User name is required.");

                RuleFor(x => x.Email)
                    .EmailAddress().WithMessage("Email is required.");

                RuleFor(x => x.Password)
                    .NotEmpty().WithMessage("Password is required.")
                    .MaximumLength(50).WithMessage("Password is long.");
            }
    }
}
