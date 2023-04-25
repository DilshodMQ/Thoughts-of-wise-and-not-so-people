namespace DsrProject.Api.Controllers.Respondents.Models
{
    public class AddCommentRequest
    {
        public string RespondentEmail { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int ThoughtId { get; set; }
    }
}
