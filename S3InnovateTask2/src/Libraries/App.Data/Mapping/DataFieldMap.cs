using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Mapping
{
    public class DataFieldMap : IEntityTypeConfiguration<DataField>
    {
        public void Configure(EntityTypeBuilder<DataField> builder)
        {
            builder.ToTable(DatabaseTableName.DataField);

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(e => e.Readings)
              .WithOne(e => e.DataField)
              .HasForeignKey(f => f.DataFieldId)
              .IsRequired();

            builder.HasData(
            new DataField { Id = 1, Name = "DataField 1" },
            new DataField { Id = 2, Name = "DataField 2" }
            );
        }
    }
}
