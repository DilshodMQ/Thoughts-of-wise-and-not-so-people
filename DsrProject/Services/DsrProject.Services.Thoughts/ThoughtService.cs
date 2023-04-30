
using AutoMapper;
using DsrProject.Common.Exceptions;
using DsrProject.Common.Validator;
using DsrProject.Context;
using DsrProject.Context.Entities;
using DsrProject.Services.Cache;
using Microsoft.EntityFrameworkCore;

namespace DsrProject.Services.Thoughts
{
    public class ThoughtService : IThoughtService
    {
        private const string contextCacheKey = "thoughts_cache_key";

        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        private readonly ICacheService cacheService;
        private readonly IModelValidator<AddThoughtModel> addThoughtModelValidator;
        private readonly IModelValidator<UpdateThoughtModel> updateThoughtModelValidator;

        public ThoughtService(
            IDbContextFactory<MainDbContext> contextFactory,
            IMapper mapper,
            ICacheService cacheService,
            IModelValidator<AddThoughtModel> addThoughtModelValidator,
            IModelValidator<UpdateThoughtModel> updateThoughtModelValidator
            )
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
            this.cacheService = cacheService;
            this.addThoughtModelValidator = addThoughtModelValidator;
            this.updateThoughtModelValidator = updateThoughtModelValidator;
        }

        public async Task<IEnumerable<ThoughtModel>> GetThoughts(int offset = 0, int limit = 10)
        {
            try
            {
                var cached_data = await cacheService.Get<IEnumerable<ThoughtModel>>(contextCacheKey);
                if (cached_data != null)
                    return cached_data;
            }
            catch
            {
                // Put log message here
            }

            await Task.Delay(5000);

            using var context = await contextFactory.CreateDbContextAsync();

            var thoughts = context
                .Thoughts
                .Include(x => x.Author)
                .Include(x=>x.Category)
                .AsQueryable();

            thoughts = thoughts
                .Skip(Math.Max(offset, 0))
                .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await thoughts.ToListAsync()).Select(thought => mapper.Map<ThoughtModel>(thought));

            await cacheService.Put(contextCacheKey, data, TimeSpan.FromSeconds(30));
            return data;
        }

        public async Task<ThoughtModel> GetThought(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var thought = await context.Thoughts.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id.Equals(id));

            var data = mapper.Map<ThoughtModel>(thought);

            return data;
        }
        public async Task<ThoughtModel> AddThought(AddThoughtModel model)
        {
            addThoughtModelValidator.Check(model);

            using var context = await contextFactory.CreateDbContextAsync();

            var thought = mapper.Map<Thought>(model);
            await context.Thoughts.AddAsync(thought);

            context.SaveChanges();

            await cacheService.Delete(contextCacheKey);
            return mapper.Map<ThoughtModel>(thought);
        }

        public async Task UpdateThought(int thoughtId, UpdateThoughtModel model)
        {
            updateThoughtModelValidator.Check(model);

            using var context = await contextFactory.CreateDbContextAsync();

            var thought = await context.Thoughts.FirstOrDefaultAsync(x => x.Id.Equals(thoughtId));

            ProcessException.ThrowIf(() => thought is null, $"The thought (id: {thoughtId}) was not found");

            thought = mapper.Map(model, thought);

            context.Thoughts.Update(thought);

            await cacheService.Delete(contextCacheKey);
            context.SaveChanges();
        }

        public async Task DeleteThought(int thoughtId)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var thought = await context.Thoughts.FirstOrDefaultAsync(x => x.Id.Equals(thoughtId))
                ?? throw new ProcessException($"The thought (id: {thoughtId}) was not found");

            context.Remove(thought);

            await cacheService.Delete(contextCacheKey);
            context.SaveChanges();
        }
    }
}
