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
    public class ThoughtUserConfiguration : IEntityTypeConfiguration<ThoughtUser>
    {
        public void Configure(EntityTypeBuilder<ThoughtUser> builder)
        {
            builder.ToTable("thoughts_users");
            builder.Property(tr => tr.Id)
                .ValueGeneratedOnAdd();
            builder.HasKey(tr => new { tr.ThoughtId, tr.UserId });
            builder.HasOne(tr => tr.Thought)
                   .WithMany(t => t.ThoughtUsers)
                   .HasForeignKey(tr => tr.ThoughtId);
            builder.HasOne(tr => tr.User)
                   .WithMany(r => r.ThoughtUsers)
                   .HasForeignKey(tr => tr.UserId);
        }

       
    }
}
