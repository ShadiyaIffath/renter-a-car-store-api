﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.DatabaseContext;

namespace Model.Migrations
{
    [DbContext(typeof(ClientDbContext))]
    [Migration("20201005034814_equipmentFix")]
    partial class equipmentFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Entities.Account", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("activatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<byte[]>("additionalIdentitfication")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("drivingLicense")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("phone")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.Property<int>("typeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("typeId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Model.Entities.AccountType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.HasKey("id");

                    b.ToTable("AccountTypes");
                });

            modelBuilder.Entity("Model.Entities.Equipment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dayAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("features")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<double>("purchasedPrice")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("categoryId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("Model.Entities.EquipmentCategory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<byte[]>("image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("id");

                    b.ToTable("EquipmentCategories");
                });

            modelBuilder.Entity("Model.Entities.Vehicle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<bool>("automatic")
                        .HasColumnType("bit");

                    b.Property<string>("carCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<DateTime>("dayAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dayRemoved")
                        .HasColumnType("datetime2");

                    b.Property<string>("engine")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<byte[]>("image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int>("typeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("typeId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Model.Entities.VehicleBooking", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("accountId")
                        .HasColumnType("int");

                    b.Property<string>("confirmationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<double>("totalCost")
                        .HasColumnType("float");

                    b.Property<int>("vehicleId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("accountId");

                    b.HasIndex("vehicleId");

                    b.ToTable("VehicleBookings");
                });

            modelBuilder.Entity("Model.Entities.VehicleType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("passengers")
                        .HasColumnType("int");

                    b.Property<double>("pricePerDay")
                        .HasColumnType("float");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("id");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("Model.Entities.Account", b =>
                {
                    b.HasOne("Model.Entities.AccountType", "type")
                        .WithMany()
                        .HasForeignKey("typeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entities.Equipment", b =>
                {
                    b.HasOne("Model.Entities.EquipmentCategory", "category")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entities.Vehicle", b =>
                {
                    b.HasOne("Model.Entities.VehicleType", "type")
                        .WithMany()
                        .HasForeignKey("typeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entities.VehicleBooking", b =>
                {
                    b.HasOne("Model.Entities.Account", "account")
                        .WithMany()
                        .HasForeignKey("accountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Vehicle", "vehicle")
                        .WithMany()
                        .HasForeignKey("vehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
