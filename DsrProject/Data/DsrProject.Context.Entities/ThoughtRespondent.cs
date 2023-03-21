namespace DsrProject.Context.Entities
{
    public class ThoughtRespondent
    {
        public int ThoughtId { get; set; }
        public Thought Thought { get; set; }
        public int RespondentId { get; set; }
        public Respondent Respondent { get; set; }
    }
}
