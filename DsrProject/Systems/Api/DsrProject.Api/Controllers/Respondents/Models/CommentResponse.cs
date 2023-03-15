namespace DsrProject.Api.Controllers.Respondents.Models
{
    public class CommentResponse
    {
        /// <summary>
        /// Thought Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Thought title
        /// </summary>
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
