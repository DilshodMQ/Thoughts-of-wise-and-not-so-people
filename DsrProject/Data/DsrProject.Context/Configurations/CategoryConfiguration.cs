using DsrProject.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DsrProject.Context.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");
            builder.HasKey(o => o.Id);
            builder.Property(t => t.Id)
                   .ValueGeneratedOnAdd();
            builder.HasIndex(t => t.Uid)
                   .IsUnique();
            builder.Property(t => t.Uid)
                   .IsRequired();
            builder.Property(t => t.Title)
                    .IsRequired()
                    .HasMaxLength(100);
        }
    }
}
