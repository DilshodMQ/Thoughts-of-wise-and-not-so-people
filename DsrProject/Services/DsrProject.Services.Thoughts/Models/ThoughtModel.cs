namespace DsrProject.Services.Thoughts;

using AutoMapper;
using DsrProject.Context.Entities;

public class ThoughtModel
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
}

public class ThoughtModelProfile : Profile
{
    public ThoughtModelProfile()
    {
        CreateMap<Thought, ThoughtModel>()
            .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
    }
}
