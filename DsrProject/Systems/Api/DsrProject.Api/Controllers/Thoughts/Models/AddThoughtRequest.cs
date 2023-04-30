using AutoMapper;
using DsrProject.Services.Thoughts;
using FluentValidation;

namespace DsrProject.API.Controllers.Models
{
    public class AddThoughtRequest
    {
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

