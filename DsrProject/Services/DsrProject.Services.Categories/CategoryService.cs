using AutoMapper;
using DsrProject.Common.Exceptions;
using DsrProject.Common.Validator;
using DsrProject.Context;
using DsrProject.Context.Entities;
using DsrProject.Services.Categories;
using Microsoft.EntityFrameworkCore;

namespace DsrProject.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private const string contextCacheKey = "categories_cache_key";

        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        private readonly IModelValidator<AddCategoryModel> addCategoryModelValidator;
        private readonly IModelValidator<UpdateCategoryModel> updateCategoryModelValidator;

        public CategoryService(
            IDbContextFactory<MainDbContext> contextFactory,
            IMapper mapper,
            IModelValidator<AddCategoryModel> addCategoryModelValidator,
            IModelValidator<UpdateCategoryModel> updateCategoryModelValidator
            )
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
            this.addCategoryModelValidator = addCategoryModelValidator;
            this.updateCategoryModelValidator = updateCategoryModelValidator;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories(int offset = 0, int limit = 10)
        {

            using var context = await contextFactory.CreateDbContextAsync();

            var categories = context
                .Categories
                .Include(x=>x.Author)
                .AsQueryable();

            categories = categories
                .Skip(Math.Max(offset, 0))
                .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await categories.ToListAsync()).Select(category => mapper.Map<CategoryModel>(category));

            return data;
        }

        public async Task<CategoryModel> GetCategory(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(id));

            var data = mapper.Map<CategoryModel>(category);

            return data;
        }
        public async Task<CategoryModel> AddCategory(AddCategoryModel model)
        {
            addCategoryModelValidator.Check(model);

            using var context = await contextFactory.CreateDbContextAsync();

            var category = mapper.Map<Category>(model);

            await context.Categories.AddAsync(category);
            context.SaveChanges();

            return mapper.Map<CategoryModel>(category);
        }

        public async Task UpdateCategory(int categoryId, UpdateCategoryModel model)
        {
            updateCategoryModelValidator.Check(model);

            using var context = await contextFactory.CreateDbContextAsync();

            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(categoryId));

            ProcessException.ThrowIf(() => category is null, $"The category (id: {categoryId}) was not found");

            category = mapper.Map(model, category);

            context.Categories.Update(category);
            context.SaveChanges();
        }

        public async Task DeleteCategory(int categoryId)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(categoryId))
                ?? throw new ProcessException($"The thought (id: {categoryId}) was not found");

            context.Remove(category);
            context.SaveChanges();
        }
    }
}
