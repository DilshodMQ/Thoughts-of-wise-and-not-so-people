using DsrProject.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DsrProject.Context.Configurations
{
    public class RespondentConfiguration : IEntityTypeConfiguration<Respondent>
    {
        public void Configure(EntityTypeBuilder<Respondent> builder)
        {
            builder.ToTable("respondents");
            builder.HasKey(o => o.Id);
            builder.Property(t => t.Id)
                   .UseIdentityByDefaultColumn();
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
