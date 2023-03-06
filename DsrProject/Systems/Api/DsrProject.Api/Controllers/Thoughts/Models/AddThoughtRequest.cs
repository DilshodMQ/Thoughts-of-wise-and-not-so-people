namespace DsrProject.API.Controllers.Models;

using AutoMapper;
using DsrProject.Services.Thoughts;
using FluentValidation;

public class AddThoughtRequest
{
    public int AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class AddThoughtResponseValidator : AbstractValidator<AddThoughtRequest>
{
    public AddThoughtResponseValidator()
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

public class AddThoughtRequestProfile : Profile
{
    public AddThoughtRequestProfile()
    {
        CreateMap<AddThoughtRequest, AddThoughtModel>()
            .ForMember(d => d.Note, a => a.MapFrom(s => s.Description));
    }
}

