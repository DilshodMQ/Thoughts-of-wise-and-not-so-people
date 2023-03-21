using DsrProject.Context.Entities.Common;

namespace DsrProject.Context.Entities
{
    public class Thought : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public ICollection<ThoughtCategory> ThoughtCategories { get; set; }
        public ICollection<ThoughtRespondent> ThoughtRespondents { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
