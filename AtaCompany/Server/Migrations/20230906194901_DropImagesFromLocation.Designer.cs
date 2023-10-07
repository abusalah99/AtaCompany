﻿// <auto-generated />
using System;
using AtaCompany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AtaCompany.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230906194901_DropImagesFromLocation")]
    partial class DropImagesFromLocation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AtaCompany.Contractor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DealBudget")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("DealDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DealType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("Penalty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WareTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WareTypeId");

                    b.ToTable("Contractor");
                });

            modelBuilder.Entity("AtaCompany.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("AtaCompany.LocationContractor", b =>
                {
                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContractorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocationId", "ContractorId");

                    b.HasIndex("ContractorId");

                    b.ToTable("LocationContractor");
                });

            modelBuilder.Entity("AtaCompany.LocationSupplier", b =>
                {
                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocationId", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("LocationSupplier");
                });

            modelBuilder.Entity("AtaCompany.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id");

                    b.HasIndex("MobileNumber")
                        .IsUnique();

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("AtaCompany.SupplierWareType", b =>
                {
                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WareTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SupplierId", "WareTypeId");

                    b.HasIndex("WareTypeId");

                    b.ToTable("SupplierWareType");
                });

            modelBuilder.Entity("AtaCompany.Ware", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EntranceDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("WareTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("WareTypeId");

                    b.ToTable("Ware");
                });

            modelBuilder.Entity("AtaCompany.WareType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("WareType");
                });

            modelBuilder.Entity("AtaCompany.Contractor", b =>
                {
                    b.HasOne("AtaCompany.WareType", "WareType")
                        .WithMany("Contractors")
                        .HasForeignKey("WareTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("AtaCompany.Payment", "Payment", b1 =>
                        {
                            b1.Property<Guid>("ContractorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("PaidMoney")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<DateTime>("PaymentDate")
                                .HasColumnType("datetime2");

                            b1.HasKey("ContractorId");

                            b1.ToTable("Contractor");

                            b1.WithOwner()
                                .HasForeignKey("ContractorId");
                        });

                    b.Navigation("Payment");

                    b.Navigation("WareType");
                });

            modelBuilder.Entity("AtaCompany.LocationContractor", b =>
                {
                    b.HasOne("AtaCompany.Contractor", "Contractor")
                        .WithMany("LocationContracts")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AtaCompany.Location", "Location")
                        .WithMany("LocationContractors")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contractor");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("AtaCompany.LocationSupplier", b =>
                {
                    b.HasOne("AtaCompany.Location", "Location")
                        .WithMany("LocationSuppliers")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AtaCompany.Supplier", "Supplier")
                        .WithMany("LocationSuppliers")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("AtaCompany.SupplierWareType", b =>
                {
                    b.HasOne("AtaCompany.Supplier", "Supplier")
                        .WithMany("SupplierWareTypes")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AtaCompany.WareType", "WareType")
                        .WithMany("SupplierWareTypes")
                        .HasForeignKey("WareTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");

                    b.Navigation("WareType");
                });

            modelBuilder.Entity("AtaCompany.Ware", b =>
                {
                    b.HasOne("AtaCompany.Location", "Location")
                        .WithMany("Wares")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AtaCompany.WareType", "WareType")
                        .WithMany("Wares")
                        .HasForeignKey("WareTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("WareType");
                });

            modelBuilder.Entity("AtaCompany.Contractor", b =>
                {
                    b.Navigation("LocationContracts");
                });

            modelBuilder.Entity("AtaCompany.Location", b =>
                {
                    b.Navigation("LocationContractors");

                    b.Navigation("LocationSuppliers");

                    b.Navigation("Wares");
                });

            modelBuilder.Entity("AtaCompany.Supplier", b =>
                {
                    b.Navigation("LocationSuppliers");

                    b.Navigation("SupplierWareTypes");
                });

            modelBuilder.Entity("AtaCompany.WareType", b =>
                {
                    b.Navigation("Contractors");

                    b.Navigation("SupplierWareTypes");

                    b.Navigation("Wares");
                });
#pragma warning restore 612, 618
        }
    }
}
