using DsrProject.Api.Controllers.Respondents.Models;
using FluentValidation;

namespace DsrProject.Api.Controllers.Respondents.Validators
{
    public class SubscribeThoughtRequestValidator : AbstractValidator<SubscribeThoughtRequest>
    {
        public SubscribeThoughtRequestValidator()
        {
            RuleFor(x => x.RespondentEmail)
               .NotEmpty().WithMessage("Respondent email is required.");

            RuleFor(x => x.ThoughtId)
                .NotEmpty().WithMessage("Thought is required.");
        }
    }
}
