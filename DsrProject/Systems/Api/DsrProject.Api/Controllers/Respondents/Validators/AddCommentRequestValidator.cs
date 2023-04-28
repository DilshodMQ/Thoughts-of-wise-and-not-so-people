using DsrProject.Api.Controllers.Respondents.Models;
using FluentValidation;

namespace DsrProject.Api.Controllers.Respondents.Validators
{
    public class AddCommentRequestValidator : AbstractValidator<AddCommentRequest>
    {
        public AddCommentRequestValidator()
        {
            RuleFor(x => x.RespondentEmail)
                .NotEmpty().WithMessage("RespondentEmail is required.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.");

            RuleFor(x => x.ThoughtId)
               .NotEmpty().WithMessage("Thought is required.");
        }
    }
}
