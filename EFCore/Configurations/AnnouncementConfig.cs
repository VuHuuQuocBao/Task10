using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task10_11.EFCore.DTOs;

namespace Task10_11.EFCore.Configurations
{
    public class AnnouncementConfig : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.ToTable("Announcement");
            builder.HasKey(an => an.Id);
            builder.Property(an => an.Title).IsRequired().HasMaxLength(400);
            builder.Property(an => an.linkImage).IsRequired();
            builder.Property(an => an.Desc).IsRequired();
            builder.Property(an => an.Date).IsRequired();
            builder.Property(an => an.Text).IsRequired();
        }
    }
}