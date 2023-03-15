namespace DsrProject.Api.Controllers.Respondents.Models
{
    public class AddCommentRequest
    {
        public int RespondentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public int ThoughtId { get; set; }
    }
}
