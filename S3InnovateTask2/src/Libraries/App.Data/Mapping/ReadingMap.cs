using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Data.Mapping
{
    public class ReadingMap : IEntityTypeConfiguration<Reading>
    {
        public void Configure(EntityTypeBuilder<Reading> builder)
        {
            builder.ToTable(DatabaseTableName.Reading);

            builder.Property(p => p.Value)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(p => p.Timestamp)
               .IsRequired();

            builder.HasIndex(r => r.Timestamp)
                   .IsUnique(false);
        }
    }
}
