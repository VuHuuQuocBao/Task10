using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task10_11.EFCore.DTOs;

namespace Task10_11.EFCore.Configurations
{
    public class QuickLinkConfig : IEntityTypeConfiguration<QuickLink>
    {
        public void Configure(EntityTypeBuilder<QuickLink> builder)
        {
            builder.ToTable("QuickLink");
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Title).IsRequired();
            builder.Property(q => q.Image).IsRequired();
        }
    }
}