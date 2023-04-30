using FluentValidation;

namespace DsrProject.Web
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; } = string.Empty;
    }

    public class CategoryModelValidator : AbstractValidator<CategoryModel>
    {
        public CategoryModelValidator()
        {
            RuleFor(v => v.Title)
                  .NotEmpty().WithMessage("Title is required")
                  .MaximumLength(256).WithMessage("Title length must be less then 256");

            RuleFor(v => v.AuthorId)
                .GreaterThan(0).WithMessage("Please, select an user");

        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<CategoryModel>.CreateWithOptions((CategoryModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
