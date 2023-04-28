using DsrProject.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DsrProject.Context.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("comments");
            builder.HasIndex(c => c.Uid)
                   .IsUnique();
            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();
            builder.Property(c => c.Uid)
                   .IsRequired();
            builder.HasOne(c => c.User)
                   .WithMany(r => r.Comments);
            builder.HasOne(c => c.Thought)
                   .WithMany(t => t.Comments);
        }
    }
}
