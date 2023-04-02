namespace DsrProject.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategories(int offset = 0, int limit = 10);
        Task<CategoryModel> GetCategory(int thoughtId);
        Task<CategoryModel> AddCategory(AddCategoryModel model);
        Task UpdateCategory(int id, UpdateCategoryModel model);
        Task DeleteCategory(int categoryId);
    }
}
