using AutoMapper;
using DsrProject.Context.Entities;

namespace DsrProject.Services.Thoughts
{
    public class ThoughtModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }

}