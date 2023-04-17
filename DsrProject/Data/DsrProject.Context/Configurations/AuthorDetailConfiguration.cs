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
            builder.HasData(new AuthorDetail { AuthorId = 1, Family = "Aliyev", Country = "UZ" , Id=1});

        }
    }
}
