using DsrProject.Context.Entities.Common;

namespace DsrProject.Context.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Thought Thought { get; set; }
        public int ThoughtId { get; set; }

    }
}
