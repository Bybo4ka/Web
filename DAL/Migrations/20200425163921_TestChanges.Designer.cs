﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ComputerServiceDbContext))]
    [Migration("20200425163921_TestChanges")]
    partial class TestChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Computers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OwnerId = 1
                        });
                });

            modelBuilder.Entity("DAL.Entities.ComputerParts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ComputerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.ToTable("ComputerParts");

                    b.HasData(
                        new
                        {
                            Id = 1
                        });
                });

            modelBuilder.Entity("DAL.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OwnerId = 0,
                            Price = 0m
                        });
                });

            modelBuilder.Entity("DAL.Entities.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nameless dude"
                        });
                });

            modelBuilder.Entity("DAL.Entities.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ComputerPartsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PartName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComputerPartsId");

                    b.HasIndex("OrderId");

                    b.ToTable("Parts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfCreation = new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Local),
                            OrderId = 1,
                            PartName = "SHS"
                        });
                });

            modelBuilder.Entity("DAL.Entities.Computer", b =>
                {
                    b.HasOne("DAL.Entities.Owner", "Owner")
                        .WithMany("Computers")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.ComputerParts", b =>
                {
                    b.HasOne("DAL.Entities.Computer", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId");
                });

            modelBuilder.Entity("DAL.Entities.Order", b =>
                {
                    b.HasOne("DAL.Entities.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.Part", b =>
                {
                    b.HasOne("DAL.Entities.ComputerParts", null)
                        .WithMany("Parts")
                        .HasForeignKey("ComputerPartsId");

                    b.HasOne("DAL.Entities.Order", "Order")
                        .WithMany("PartsForReplacement")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}