namespace DsrProject.Services.Respondents.Models
{
    public class AddCommentModel
    {
        public string Content { get; set; }

        public string RespondentEmail { get; set; }

        public int ThoughtId { get; set; }
    }
}
