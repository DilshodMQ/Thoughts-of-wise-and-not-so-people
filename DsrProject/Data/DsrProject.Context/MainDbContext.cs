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
        public MainDbContext(DbContextOptions<MainDbContext> options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().ToTable("authors");
            modelBuilder.Entity<Author>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Author>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<Author>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<AuthorDetail>().ToTable("author_details");
            modelBuilder.Entity<AuthorDetail>().HasOne(x => x.Author).WithOne(x => x.Detail).HasPrincipalKey<AuthorDetail>(x => x.Id);

            modelBuilder.Entity<Thought>().ToTable("thoughts");
            modelBuilder.Entity<Thought>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<Thought>().Property(x => x.Title).HasMaxLength(250);
            modelBuilder.Entity<Thought>().HasOne(x => x.Author).WithMany(x => x.Thoughts).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<Category>().Property(x => x.Title).HasMaxLength(100);
            modelBuilder.Entity<Category>().HasMany(x => x.Thoughts).WithMany(x => x.Categories).UsingEntity(t => t.ToTable("thoughts_categories"));

            modelBuilder.Entity<Respondent>().ToTable("respondents");
            modelBuilder.Entity<Respondent>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<Respondent>().Property(x => x.Email).HasMaxLength(100);
            modelBuilder.Entity<Respondent>().HasMany(x => x.Thoughts).WithMany(x => x.Respondents).UsingEntity(t => t.ToTable("respondents_categories"));

        }
    }
}
