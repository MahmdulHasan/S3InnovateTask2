using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Data.Mapping
{
    public class ObjectsMap : IEntityTypeConfiguration<Objects>
    {
        public void Configure(EntityTypeBuilder<Objects> builder)
        {
            builder.ToTable(DatabaseTableName.Object);

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(e => e.Readings)
              .WithOne(e => e.Objects)
              .HasForeignKey(f => f.ObjectId)
              .IsRequired();

            builder.HasData(
                new Objects { Id = 1, Name = "Object 1" },
                new Objects { Id = 2, Name = "Object 2" }
            );
        }
    }
}
