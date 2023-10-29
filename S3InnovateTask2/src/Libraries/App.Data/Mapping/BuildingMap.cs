using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Mapping
{
    public class BuildingMap : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable(DatabaseTableName.Building);

            builder.Property(p  => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Location)
                .HasMaxLength(50);

            builder.HasMany(e => e.Readings)
              .WithOne(e => e.Building)
              .HasForeignKey(ul => ul.BuildingId)
              .IsRequired();

            builder.HasData(
            new Building { Id = 1, Name = "Building 1", Location = "Location 1" },
            new Building { Id = 2, Name = "Building 2", Location = "Location 2" }
            );
        }
    }
}
