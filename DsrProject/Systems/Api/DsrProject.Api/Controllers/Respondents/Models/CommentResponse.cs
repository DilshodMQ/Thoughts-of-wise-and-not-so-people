namespace DsrProject.Api.Controllers.Respondents.Models
{
    public class CommentResponse
    {
        /// <summary>
        /// Comment Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Author Id
        /// </summary>
        public int RespondentId { get; set; }

        public int ThoughtId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
