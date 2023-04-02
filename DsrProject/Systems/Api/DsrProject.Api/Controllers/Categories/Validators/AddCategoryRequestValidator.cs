using DsrProject.API.Controllers.Models;
using FluentValidation;

namespace DsrProject.Api.Controllers.Categories.Validators
{
    public class AddCategoryRequestValidator : AbstractValidator<AddCategoryRequest>
    {
        public AddCategoryRequestValidator()
        {
            RuleFor(x => x.Title)
               .NotEmpty().WithMessage("Title is required.")
               .MaximumLength(50).WithMessage("Title is long.");
        }
    }
}
