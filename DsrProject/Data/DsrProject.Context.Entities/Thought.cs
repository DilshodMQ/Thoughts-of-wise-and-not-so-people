using DsrProject.Context.Entities.Common;

namespace DsrProject.Context.Entities
{
    public class Thought : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ThoughtUser> ThoughtUsers { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
