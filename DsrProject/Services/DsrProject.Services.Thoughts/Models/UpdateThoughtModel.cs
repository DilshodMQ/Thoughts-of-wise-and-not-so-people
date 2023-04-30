using AutoMapper;
using DsrProject.Context.Entities;
using FluentValidation;

namespace DsrProject.Services.Thoughts
{
    public class UpdateThoughtModel
    {
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }

}