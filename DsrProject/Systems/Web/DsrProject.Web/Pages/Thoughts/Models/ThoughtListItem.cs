namespace DsrProject.Web
{

    public class ThoughtListItem
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}