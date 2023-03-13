using DsrProject.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DsrProject.Context.Configurations
{
    public class AuthorDetailConfiguration : IEntityTypeConfiguration<AuthorDetail>
    {
        public void Configure(EntityTypeBuilder<AuthorDetail> builder)
        {
            builder.ToTable("authordetails");
            builder.HasKey(ad => ad.Id);
            //builder.HasOne(ad => ad.Author)
            //       .WithOne(a => a.Detail)
            //       .HasForeignKey("Id");

        }
    }
}
