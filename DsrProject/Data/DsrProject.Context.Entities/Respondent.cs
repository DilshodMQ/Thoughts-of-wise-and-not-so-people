using DsrProject.Context.Entities.Common;

namespace DsrProject.Context.Entities
{
    public class Respondent : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<ThoughtRespondent>? ThoughtRespondents { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
