using DsrProject.Context.Entities.Common;

namespace DsrProject.Context.Entities
{
    public class ThoughtUser : BaseEntity
    {
        public int ThoughtId { get; set; }
        public Thought Thought { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
