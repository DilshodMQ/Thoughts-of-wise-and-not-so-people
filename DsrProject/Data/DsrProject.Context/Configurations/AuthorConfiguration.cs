
using DsrProject.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DsrProject.Context.Configurations
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("authors");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                   .ValueGeneratedOnAdd();
            builder.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.HasIndex(t => t.Uid)
                   .IsUnique();
            builder.Property(t => t.Uid)
                   .IsRequired();
            builder.HasOne(a => a.Detail)
                   .WithOne(x => x.Author)
                   .HasForeignKey<AuthorDetail>(x => x.AuthorId);
            builder.HasData(new Author { Id = 1, Name = "Ali" });
        }

    }
}
