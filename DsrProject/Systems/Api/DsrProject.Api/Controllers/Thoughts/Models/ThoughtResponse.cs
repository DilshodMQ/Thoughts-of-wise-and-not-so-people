namespace DsrProject.API.Controllers.Models;

using AutoMapper;
using DsrProject.Services.Thoughts;

public class ThoughtResponse
{
    /// <summary>
    /// Book Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Book title
    /// </summary>
    public string Title { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class ThoughtResponseProfile : Profile
{
    public ThoughtResponseProfile()
    {
        CreateMap<ThoughtModel, ThoughtResponse>()
            .ForMember(d => d.Description, a => a.MapFrom(s => s.Note));
    }
}
