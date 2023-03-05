using DsrProject.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsrProject.Context.Configurations
{
    public class ThoughtRespondentConfiguration : IEntityTypeConfiguration<ThoughtRespondent>
    {
        public void Configure(EntityTypeBuilder<ThoughtRespondent> builder)
        {
            builder.ToTable("thoughts_respondents");
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
