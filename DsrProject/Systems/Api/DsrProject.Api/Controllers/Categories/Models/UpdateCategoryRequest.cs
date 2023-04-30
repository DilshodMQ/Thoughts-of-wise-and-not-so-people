namespace DsrProject.API.Controllers.Models
{
    public class UpdateCategoryRequest
    {
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
    }
}