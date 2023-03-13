using DsrProject.Context.Configurations;
using DsrProject.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace DsrProject.Context
{
    public class MainDbContext : DbContext
    {
        public DbSet<Thought> Thoughts  { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorDetail> AuthorDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Respondent> Respondents { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ThoughtCategory> ThoughtCategories { get; set; }
        public DbSet<ThoughtRespondent> ThoughtRespondents { get; set; }
        public MainDbContext(DbContextOptions<MainDbContext> options) :base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new RespondentConfiguration());
            modelBuilder.ApplyConfiguration(new ThoughtCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ThoughtRespondentConfiguration());
            modelBuilder.ApplyConfiguration(new ThoughtConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
