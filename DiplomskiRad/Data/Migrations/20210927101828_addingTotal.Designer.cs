﻿// <auto-generated />
using System;
using DiplomskiRad.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiplomskiRad.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210927101828_addingTotal")]
    partial class addingTotal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DiplomskiRad.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RolaId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RolaId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DiplomskiRad.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AirConditioner")
                        .HasColumnType("bit");

                    b.Property<bool>("Blueotooth")
                        .HasColumnType("bit");

                    b.Property<bool>("CentralLocking")
                        .HasColumnType("bit");

                    b.Property<int>("Door")
                        .HasColumnType("int");

                    b.Property<string>("GearShift")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("Mp")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NavigationSystem")
                        .HasColumnType("bit");

                    b.Property<bool>("ParkingSensors")
                        .HasColumnType("bit");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PricePerDay")
                        .HasColumnType("int");

                    b.Property<int>("Seat")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("DiplomskiRad.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("DateRange")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PricePerDay")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CarId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("DiplomskiRad.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("DiplomskiRad.Entities.AppUser", b =>
                {
                    b.HasOne("DiplomskiRad.Entities.Role", "Rola")
                        .WithMany("AppUsers")
                        .HasForeignKey("RolaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rola");
                });

            modelBuilder.Entity("DiplomskiRad.Entities.Reservation", b =>
                {
                    b.HasOne("DiplomskiRad.Entities.AppUser", "AppUser")
                        .WithMany("Reservations")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiplomskiRad.Entities.Car", "Car")
                        .WithMany("Reservations")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("DiplomskiRad.Entities.AppUser", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("DiplomskiRad.Entities.Car", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("DiplomskiRad.Entities.Role", b =>
                {
                    b.Navigation("AppUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
