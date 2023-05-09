using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task10_11.EFCore.DTOs;

namespace Task10_11.EFCore.Configurations
{
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Day).IsRequired();
            builder.Property(e => e.Month).IsRequired();
            builder.Property(e => e.Desc).IsRequired();
            builder.Property(e => e.Time).IsRequired();
        }
    }
}