using DsrProject.Context.Entities.Common;

namespace DsrProject.Context.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public Respondent Respondent { get; set; }
        public int RespondentId { get; set; }
        public Thought Thought { get; set; }
        public int ThoughtId { get; set; }

    }
}
