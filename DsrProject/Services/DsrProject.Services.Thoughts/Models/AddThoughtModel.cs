namespace DsrProject.Services.Thoughts;

using AutoMapper;
using DsrProject.Context.Entities;
using FluentValidation;

public class AddThoughtModel
{
    public int AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
}

public class AddThoughtModelValidator : AbstractValidator<AddThoughtModel>
{
    public AddThoughtModelValidator()
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

public class AddThoughtModelProfile : Profile
{
    public AddThoughtModelProfile()
    {
        CreateMap<AddThoughtModel, Thought>()
            .ForMember(d => d.Description, a => a.MapFrom(s => s.Note));
    }
}