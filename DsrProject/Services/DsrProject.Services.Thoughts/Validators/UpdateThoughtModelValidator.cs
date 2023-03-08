using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsrProject.Services.Thoughts.Validators
{
    public class UpdateThoughtModelValidator : AbstractValidator<UpdateThoughtModel>
    {
        public UpdateThoughtModelValidator()
        {
            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage("Author is required.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title is long.");

            RuleFor(x => x.Note)
                .MaximumLength(2000).WithMessage("Description is long.");
        }
    }
}
