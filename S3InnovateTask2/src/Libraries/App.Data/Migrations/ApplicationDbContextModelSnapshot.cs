﻿// <auto-generated />
using System;
using App.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("App.Data.Entities.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Building", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "Location 1",
                            Name = "Building 1"
                        },
                        new
                        {
                            Id = 2,
                            Location = "Location 2",
                            Name = "Building 2"
                        });
                });

            modelBuilder.Entity("App.Data.Entities.DataField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("DataField", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "DataField 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "DataField 2"
                        });
                });

            modelBuilder.Entity("App.Data.Entities.Objects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Object", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Object 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Object 2"
                        });
                });

            modelBuilder.Entity("App.Data.Entities.Reading", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<int>("DataFieldId")
                        .HasColumnType("int");

                    b.Property<int>("ObjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("DataFieldId");

                    b.HasIndex("ObjectId");

                    b.HasIndex("Timestamp");

                    b.ToTable("Reading", (string)null);
                });

            modelBuilder.Entity("App.Data.Entities.Reading", b =>
                {
                    b.HasOne("App.Data.Entities.Building", "Building")
                        .WithMany("Readings")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Data.Entities.DataField", "DataField")
                        .WithMany("Readings")
                        .HasForeignKey("DataFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Data.Entities.Objects", "Objects")
                        .WithMany("Readings")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("DataField");

                    b.Navigation("Objects");
                });

            modelBuilder.Entity("App.Data.Entities.Building", b =>
                {
                    b.Navigation("Readings");
                });

            modelBuilder.Entity("App.Data.Entities.DataField", b =>
                {
                    b.Navigation("Readings");
                });

            modelBuilder.Entity("App.Data.Entities.Objects", b =>
                {
                    b.Navigation("Readings");
                });
#pragma warning restore 612, 618
        }
    }
}
