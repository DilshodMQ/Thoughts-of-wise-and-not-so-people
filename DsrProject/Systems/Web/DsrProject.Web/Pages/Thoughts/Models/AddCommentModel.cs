namespace DsrProject.Web
{
    public class AddCommentModel
    {
        public string  content { get; set; }

        public int thoughtId { get; set; }

        public string respondentEmail { get; set; }
    }
}
