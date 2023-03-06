namespace DsrProject.API.Controllers.Models;

using AutoMapper;
using DsrProject.Services.Thoughts;
using FluentValidation;

public class UpdateThoughtRequest
{
    public int AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class UpdateThoughtRequestValidator : AbstractValidator<UpdateThoughtRequest>
{
    public UpdateThoughtRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(50).WithMessage("Title is long.");

        RuleFor(x => x.Description)
            .MaximumLength(2000).WithMessage("Description is long.");
    }
}

public class UpdateThoughtRequestProfile : Profile
{
    public UpdateThoughtRequestProfile()
    {
        CreateMap<UpdateThoughtRequest, UpdateThoughtModel>()
            .ForMember(d => d.Note, a => a.MapFrom(s => s.Description));
    }
}
