using DsrProject.Services.Respondents.Models;
using FluentValidation;

namespace DsrProject.Services.Respondents.Validators
{
    public class AddCommentModelValidator :AbstractValidator<AddCommentModel>
    {
        public AddCommentModelValidator()
        {
            RuleFor(x => x.ThoughtId)
                .NotEmpty().WithMessage("Thought is required.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.");

            RuleFor(x => x.RespondentId)
                .NotEmpty().WithMessage("Respondent is required.");
        }
    }
}
