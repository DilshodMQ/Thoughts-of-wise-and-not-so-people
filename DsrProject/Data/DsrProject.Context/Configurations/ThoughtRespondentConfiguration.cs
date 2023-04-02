using DsrProject.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DsrProject.Context.Configurations
{
    public class ThoughtRespondentConfiguration : IEntityTypeConfiguration<ThoughtRespondent>
    {
        public void Configure(EntityTypeBuilder<ThoughtRespondent> builder)
        {
            builder.ToTable("thoughts_respondents");
            builder.Property(tr => tr.Id)
                .ValueGeneratedOnAdd();
            builder.HasKey(tr => new { tr.ThoughtId, tr.RespondentId });
            builder.HasOne(tr => tr.Thought)
                   .WithMany(t => t.ThoughtRespondents)
                   .HasForeignKey(tr => tr.ThoughtId);
            builder.HasOne(tr => tr.Respondent)
                   .WithMany(r => r.ThoughtRespondents)
                   .HasForeignKey(tr => tr.RespondentId);
        }
    }
}
