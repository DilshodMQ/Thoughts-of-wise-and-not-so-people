namespace DsrProject.Web
{
    public class CategoryListItem
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}
