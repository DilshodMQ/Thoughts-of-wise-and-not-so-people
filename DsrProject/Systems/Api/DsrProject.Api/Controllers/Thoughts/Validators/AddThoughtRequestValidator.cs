using DsrProject.API.Controllers.Models;
using FluentValidation;

namespace DsrProject.Api.Controllers.Thoughts.Validators
{
    public class AddThoughtRequestValidator : AbstractValidator<AddThoughtRequest>
    {
        public AddThoughtRequestValidator()
        {
            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage("Author is required.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title is long.");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Description is long.");
        }
    }
}
