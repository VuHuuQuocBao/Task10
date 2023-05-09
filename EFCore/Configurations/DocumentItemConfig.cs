using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task10_11.EFCore.DTOs;

namespace Task10_11.EFCore.Configurations
{
    public class DocumentItemConfig : IEntityTypeConfiguration<DocumentItem>
    {
        public void Configure(EntityTypeBuilder<DocumentItem> builder)
        {
            builder.ToTable("DocumentItem");
            builder.HasKey(dt => dt.Id);
            builder.Property(dt => dt.Title).IsRequired();
            builder.Property(dt => dt.Type).IsRequired();
            builder.HasOne(dt => dt.DocumentData)
                .WithMany(e => e.documentItemDatas)
                .HasForeignKey(e => e.DocumentId)
                .HasConstraintName("FK_DocumentItem_Document");
        }
    }
}