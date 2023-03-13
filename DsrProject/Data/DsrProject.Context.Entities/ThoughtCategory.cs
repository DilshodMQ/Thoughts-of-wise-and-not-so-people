using DsrProject.Context.Entities.Common;

namespace DsrProject.Context.Entities
{
    public class ThoughtCategory:BaseEntity
    {
        public int ThoughtId { get; set; }
        public Thought Thought { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
