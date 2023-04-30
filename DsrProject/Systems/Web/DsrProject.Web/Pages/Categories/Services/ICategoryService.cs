using DsrProject.Web;

namespace DsrProject.Web
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListItem>> GetCategories(int offset = 0, int limit = 10);
        Task<CategoryListItem> GetCategory(int categoryId);
        Task AddCategory(CategoryModel model);
        Task EditCategory(int categoryId, CategoryModel model);
        Task DeleteCategory(int categoryId);

        Task<IEnumerable<AuthorModel>> GetAuthorList();
    }
}
