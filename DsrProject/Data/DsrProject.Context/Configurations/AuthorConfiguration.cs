
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
            builder.HasKey(o => o.Id);
            builder.Property(t => t.Id)
                   .UseIdentityByDefaultColumn();
            builder.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.HasIndex(t => t.Uid)
                   .IsUnique();
            builder.Property(t => t.Uid)
                   .IsRequired();
            builder.HasOne(o => o.Detail)
               .WithOne(x => x.Author)
               .HasForeignKey<AuthorDetail>(x => x.Id);
        }

    }
}
