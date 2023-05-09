using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task10_11.EFCore.DTOs;

namespace Task10_11.EFCore.Configurations
{
    public class NewConfig : IEntityTypeConfiguration<New>
    {
        public void Configure(EntityTypeBuilder<New> builder)
        {
            builder.ToTable("New");
            builder.HasKey(an => an.Id);
            builder.Property(an => an.Title).IsRequired().HasMaxLength(250);
            builder.Property(an => an.linkImage).IsRequired();
            builder.Property(an => an.Desc).IsRequired();
            builder.Property(an => an.Date).IsRequired();
        }
    }
}