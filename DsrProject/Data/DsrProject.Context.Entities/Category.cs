using DsrProject.Context.Entities.Common;

namespace DsrProject.Context.Entities
{
    public class Category : BaseEntity
    {
        public string  Title { get; set; }
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<Thought> Thoughts { get; set; }
    }
}
