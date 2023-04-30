using DsrProject.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DsrProject.Context.Configurations
{
    public class ThoughtConfiguration : IEntityTypeConfiguration<Thought>
    {
        public void Configure(EntityTypeBuilder<Thought> builder)
        {
            builder.ToTable("thoughts");
            builder.HasIndex(t => t.Uid)
                   .IsUnique();
            builder.Property(t => t.Uid)
                   .IsRequired();
            builder.Property(t => t.Id)
                   .ValueGeneratedOnAdd();
            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(250);
            builder.Property(x => x.Description)
                  .IsRequired();
            builder.HasOne(t => t.Author)
                   .WithMany(a => a.Thoughts)
                   .HasForeignKey(t => t.AuthorId);
            builder.HasOne(t => t.Category)
                  .WithMany(a => a.Thoughts)
                  .HasForeignKey(t => t.CategoryId);
            builder.HasData(new Thought { Id = 1, AuthorId= 1, CategoryId=1, Description="Hello world", Title="Best" });
            builder.HasData(new Thought { Id = 2, AuthorId = 2, CategoryId=1, Description = "Hello programmer", Title = "Worst" });
        }
    }
}
