﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleRental.Data;

namespace VehicleRental.Data.Migrations
{
    [DbContext(typeof(VehicleRentalDBContext))]
    [Migration("20200703013455_License ID added to DriversLicense Model")]
    partial class LicenseIDaddedtoDriversLicenseModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VehicleRental.Data.Models.BranchHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BranchId");

                    b.Property<int>("CloseTime");

                    b.Property<int>("DayOfWeek");

                    b.Property<int>("OpenTime");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("BranchHours");
                });

            modelBuilder.Entity("VehicleRental.Data.Models.Checkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DriverLicenseId");

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("VehicleRentalAssetId");

                    b.HasKey("Id");

                    b.HasIndex("DriverLicenseId");

                    b.HasIndex("VehicleRentalAssetId");

                    b.ToTable("Checkouts");
                });

            modelBuilder.Entity("VehicleRental.Data.Models.CheckoutHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CheckedIn");

                    b.Property<DateTime>("CheckedOut");

                    b.Property<int>("DriverLicenseId");

                    b.Property<int>("VehicleRentalAssetId");

                    b.HasKey("Id");

                    b.HasIndex("DriverLicenseId");

                    b.HasIndex("VehicleRentalAssetId");

                    b.ToTable("CheckoutHistories");
                });

            modelBuilder.Entity("VehicleRental.Data.Models.DriverLicense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpiryDate");

                    b.Property<double>("Fees");

                    b.Property<DateTime>("IssueDate");

                    b.Property<string>("LicenseID");

                    b.HasKey("Id");

                    b.ToTable("DriverLicenses");
                });

            modelBuilder.Entity("VehicleRental.Data.Models.Hold", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HoldPlaced");

                    b.Property<int?>("VehicleRentalAssetId");

                    b.HasKey("Id");

                    b.HasIndex("VehicleRentalAssetId");

                    b.ToTable("Holds");
                });

            modelBuilder.Entity("VehicleRental.Data.Models.Patron", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<int?>("DriverLicenseId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("TelephoneNumber");

                    b.Property<int?>("VehicleRentalBranchId");

                    b.HasKey("Id");

                    b.HasIndex("DriverLicenseId");

                    b.HasIndex("VehicleRentalBranchId");

                    b.ToTable("Patrons");
                });

            modelBuilder.Entity("VehicleRental.Data.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("VehicleRental.Data.Models.VehicleRentalAsset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cost");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("ImageUrl");

                    b.Property<int?>("LocationId");

                    b.Property<string>("Make")
                        .IsRequired();

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("StatusId");

                    b.ToTable("VehicleRentalAssets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("VehicleRentalAsset");
                });

            modelBuilder.Entity("VehicleRental.Data.Models.VehicleRentalBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime>("OpenDate");

                    b.Property<string>("Province")
                        .IsRequired();

                    b.Property<string>("Telephone");

                    b.HasKey("Id");

                    b.ToTable("VehicleRentalBranches");
                });

            modelBuilder.Entity("VehicleRental.Data.Models.Car", b =>
                {
                    b.HasBaseType("VehicleRental.Data.Models.VehicleRentalAsset");

                    b.Property<int>("Bags");

                    b.Property<string>("BodyType")
                        .IsRequired();

                    b.Property<string>("Options")
                        .IsRequired();

                    b.Property<int>("Passengers");

                    b.Property<string>("VIN")
                        .IsRequired();

                    b.ToTable("Car");

                    b.HasDiscriminator().HasValue("Car");
                });

            modelBuilder.Entity("VehicleRental.Data.Models.BranchHour", b =>
                {
                    b.HasOne("VehicleRental.Data.Models.VehicleRentalBranch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId");
                });

            modelBuilder.Entity("VehicleRental.Data.Models.Checkout", b =>
                {
                    b.HasOne("VehicleRental.Data.Models.DriverLicense", "DriverLicense")
                        .WithMany("Checkouts")
                        .HasForeignKey("DriverLicenseId");

                    b.HasOne("VehicleRental.Data.Models.VehicleRentalAsset", "VehicleRentalAsset")
                        .WithMany()
                        .HasForeignKey("VehicleRentalAssetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VehicleRental.Data.Models.CheckoutHistory", b =>
                {
                    b.HasOne("VehicleRental.Data.Models.DriverLicense", "DriverLicense")
                        .WithMany()
                        .HasForeignKey("DriverLicenseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VehicleRental.Data.Models.VehicleRentalAsset", "VehicleRentalAsset")
                        .WithMany()
                        .HasForeignKey("VehicleRentalAssetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VehicleRental.Data.Models.Hold", b =>
                {
                    b.HasOne("VehicleRental.Data.Models.VehicleRentalAsset", "VehicleRentalAsset")
                        .WithMany()
                        .HasForeignKey("VehicleRentalAssetId");
                });

            modelBuilder.Entity("VehicleRental.Data.Models.Patron", b =>
                {
                    b.HasOne("VehicleRental.Data.Models.DriverLicense", "DriverLicense")
                        .WithMany()
                        .HasForeignKey("DriverLicenseId");

                    b.HasOne("VehicleRental.Data.Models.VehicleRentalBranch", "VehicleRentalBranch")
                        .WithMany("Patrons")
                        .HasForeignKey("VehicleRentalBranchId");
                });

            modelBuilder.Entity("VehicleRental.Data.Models.VehicleRentalAsset", b =>
                {
                    b.HasOne("VehicleRental.Data.Models.VehicleRentalBranch", "Location")
                        .WithMany("VehicleRentalAssets")
                        .HasForeignKey("LocationId");

                    b.HasOne("VehicleRental.Data.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
