using DsrProject.Context.Configurations;
using DsrProject.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsrProject.Context
{
    public class MainDbContext : DbContext
    {
        public DbSet<Thought> Thoughts  { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorDetail> AuthorDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Respondent> Respondents { get; set; }

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
            base.OnModelCreating(modelBuilder);
        }
    }
}
