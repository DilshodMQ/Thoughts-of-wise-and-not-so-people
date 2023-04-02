using DsrProject.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DsrProject.Context.Configurations
{
    public class RespondentConfiguration : IEntityTypeConfiguration<Respondent>
    {
        public void Configure(EntityTypeBuilder<Respondent> builder)
        {
            builder.ToTable("respondents");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();
            builder.HasIndex(t => t.Uid)
                   .IsUnique();
            builder.Property(t => t.Uid)
                   .IsRequired();
            builder.Property(r => r.Email)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
