using AutoMapper;
using DsrProject.Context.Entities;
using FluentValidation;

namespace DsrProject.Services.Thoughts
{
    public class AddThoughtModel
    {
        public int AuthorId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }
   
}