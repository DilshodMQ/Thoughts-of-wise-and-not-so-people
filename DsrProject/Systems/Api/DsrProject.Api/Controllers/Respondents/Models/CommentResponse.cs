namespace DsrProject.Api.Controllers.Respondents.Models
{
    public class CommentResponse
    {
        /// <summary>
        /// Comment Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User Id
        /// </summary>
        public Guid UserId { get; set; }

        public int ThoughtId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
