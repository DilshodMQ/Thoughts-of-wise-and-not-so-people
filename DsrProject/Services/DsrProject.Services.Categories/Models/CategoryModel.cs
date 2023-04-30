namespace DsrProject.Services.Categories
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; }
        public int AuthorId { get; set; }
    }

}