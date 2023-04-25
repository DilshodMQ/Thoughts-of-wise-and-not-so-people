namespace DsrProject.Services.Respondents.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int ThoughtId { get; set; }
        public string Thought { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
