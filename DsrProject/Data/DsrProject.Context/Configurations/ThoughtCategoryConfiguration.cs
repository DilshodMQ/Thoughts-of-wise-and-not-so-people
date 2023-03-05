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
    public class ThoughtCategoryConfiguration : IEntityTypeConfiguration<ThoughtCategory>
    {
        public void Configure(EntityTypeBuilder<ThoughtCategory> builder)
        {
            builder.ToTable("thoughts_categories");
            builder.HasKey(tc => new { tc.ThoughtId, tc.CategoryId });
            builder.HasOne(tc => tc.Thought)
                   .WithMany(t => t.ThoughtCategories)
                   .HasForeignKey(tc => tc.ThoughtId);
            builder.HasOne(tc => tc.Category)
                   .WithMany(c => c.ThoughtCategories)
                   .HasForeignKey(tc => tc.CategoryId);

        }
    }
}
