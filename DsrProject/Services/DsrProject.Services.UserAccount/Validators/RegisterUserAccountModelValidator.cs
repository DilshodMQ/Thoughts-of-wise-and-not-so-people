using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsrProject.Services.UserAccount.Validators
{
    public class RegisterUserAccountModelValidator : AbstractValidator<RegisterUserAccountModel>
    {
        public RegisterUserAccountModelValidator()
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
