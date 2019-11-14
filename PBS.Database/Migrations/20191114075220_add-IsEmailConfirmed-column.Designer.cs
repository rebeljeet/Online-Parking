﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PBS.Database.Context;

namespace PBS.Database.Migrations
{
    [DbContext(typeof(PbsDbContext))]
    [Migration("20191114075220_add-IsEmailConfirmed-column")]
    partial class addIsEmailConfirmedcolumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PBS.Database.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .IsRequired();

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("District");

                    b.Property<string>("LandMark");

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.Property<string>("State");

                    b.Property<string>("SubDistrict");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PBS.Database.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("EndDateTime");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsConfirmed");

                    b.Property<int>("SlotId");

                    b.Property<DateTime>("StartDateTime");

                    b.Property<string>("VehicleNumber")
                        .IsRequired()
                        .HasMaxLength(13);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SlotId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("PBS.Database.Models.ParkingLot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsAproved");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("OwnerId");

                    b.ToTable("ParkingLots");
                });

            modelBuilder.Entity("PBS.Database.Models.ParkingLotImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageName");

                    b.Property<int>("ParkingLotId");

                    b.HasKey("Id");

                    b.HasIndex("ParkingLotId");

                    b.ToTable("ParkingLotImages");
                });

            modelBuilder.Entity("PBS.Database.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PBS.Database.Models.Slot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("HourlyRate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<bool>("IsBooked");

                    b.Property<int>("ParkingLotId");

                    b.Property<int>("SlotTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ParkingLotId");

                    b.HasIndex("SlotTypeId");

                    b.ToTable("Slots");
                });

            modelBuilder.Entity("PBS.Database.Models.SlotType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SlotTypes");
                });

            modelBuilder.Entity("PBS.Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<string>("ContectNumber")
                        .HasMaxLength(10);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsEmailConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PBS.Database.Models.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimTitle")
                        .IsRequired();

                    b.Property<string>("ClaimType")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("PBS.Database.Models.Booking", b =>
                {
                    b.HasOne("PBS.Database.Models.User", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PBS.Database.Models.Slot", "Slot")
                        .WithMany("Bookings")
                        .HasForeignKey("SlotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PBS.Database.Models.ParkingLot", b =>
                {
                    b.HasOne("PBS.Database.Models.Address", "Address")
                        .WithMany("ParkingLots")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PBS.Database.Models.User", "Owner")
                        .WithMany("ParkingLots")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PBS.Database.Models.ParkingLotImage", b =>
                {
                    b.HasOne("PBS.Database.Models.ParkingLot", "ParkingLot")
                        .WithMany("ParkingLotImages")
                        .HasForeignKey("ParkingLotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PBS.Database.Models.Slot", b =>
                {
                    b.HasOne("PBS.Database.Models.ParkingLot", "ParkingLot")
                        .WithMany("Slots")
                        .HasForeignKey("ParkingLotId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PBS.Database.Models.SlotType", "SlotType")
                        .WithMany("Slots")
                        .HasForeignKey("SlotTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PBS.Database.Models.User", b =>
                {
                    b.HasOne("PBS.Database.Models.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PBS.Database.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PBS.Database.Models.UserClaim", b =>
                {
                    b.HasOne("PBS.Database.Models.User", "User")
                        .WithMany("UserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
