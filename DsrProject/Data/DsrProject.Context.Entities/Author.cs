using DsrProject.Context.Entities.Common;

namespace DsrProject.Context.Entities
{
    public class Author : BaseEntity
    {
        public string  Name { get; set; }
        public AuthorDetail? Detail { get; set; }
        public ICollection<Thought> Thoughts { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
