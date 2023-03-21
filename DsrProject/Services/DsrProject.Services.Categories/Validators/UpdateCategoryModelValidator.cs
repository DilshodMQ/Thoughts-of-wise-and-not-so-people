using DsrProject.Services.Categories;
using FluentValidation;

namespace DsrProject.Services.Categories.Validators
{
    public class UpdateCategoryModelValidator : AbstractValidator<UpdateCategoryModel>
    {
        public UpdateCategoryModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title is long.");
        }
    }
}
