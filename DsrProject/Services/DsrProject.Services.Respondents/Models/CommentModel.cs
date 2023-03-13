namespace DsrProject.Services.Respondents.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int RespondentId { get; set; }
        public int ThoughtId { get; set; }
        public string Respondent { get; set; } = string.Empty;
        public string Thought { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
