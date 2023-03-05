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
    public class ThoughtConfiguration : IEntityTypeConfiguration<Thought>
    {
        public void Configure(EntityTypeBuilder<Thought> builder)
        {
            builder.ToTable("thoughts");
            builder.HasKey(o => o.Id);
            builder.Property(t => t.Id)
                   .UseIdentityByDefaultColumn();
            builder.HasIndex(t => t.Uid)
                   .IsUnique();
            builder.Property(t => t.Uid)
                   .IsRequired();
            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(250);
            builder.HasOne(t => t.Author)
                   .WithMany(a => a.Thoughts);
        }
    }
}
