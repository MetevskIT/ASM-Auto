﻿// <auto-generated />
using System;
using ASM_Auto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASM_Auto.Data.Migrations
{
    [DbContext(typeof(ASMAutoDbContext))]
    [Migration("20221205211629_addCart")]
    partial class addCart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ASM_Auto.Data.Models.Car.CarMake", b =>
                {
                    b.Property<int>("CarMakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarMakeId"), 1L, 1);

                    b.Property<string>("CarMakeText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarMakeId");

                    b.ToTable("CarsMakes");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Car.CarModel", b =>
                {
                    b.Property<int>("CarModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarModelId"), 1L, 1);

                    b.Property<int>("CarMakeId")
                        .HasColumnType("int");

                    b.Property<string>("CarModelText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarModelId");

                    b.HasIndex("CarMakeId");

                    b.ToTable("CarsModels");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Cart", b =>
                {
                    b.Property<Guid>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProductCount")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Theme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ContactId");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<DateTime>("OrderedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AddDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("CarMakeId")
                        .HasColumnType("int");

                    b.Property<int?>("CarModelId")
                        .HasColumnType("int");

                    b.Property<int?>("CleaningAccessoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExteriorsAccessoryId")
                        .HasColumnType("int");

                    b.Property<int?>("FoilsColorId")
                        .HasColumnType("int");

                    b.Property<int?>("FoilsPurposeId")
                        .HasColumnType("int");

                    b.Property<int?>("FoilsTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("FreeDelivery")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InteriorsAccessoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("LedlightsColorId")
                        .HasColumnType("int");

                    b.Property<int?>("LedlightsFormatId")
                        .HasColumnType("int");

                    b.Property<int?>("LedlightsPowerId")
                        .HasColumnType("int");

                    b.Property<int?>("LedlightsTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("MatsTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductTypeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CarMakeId");

                    b.HasIndex("CarModelId");

                    b.HasIndex("CleaningAccessoryId");

                    b.HasIndex("ExteriorsAccessoryId");

                    b.HasIndex("FoilsColorId");

                    b.HasIndex("FoilsPurposeId");

                    b.HasIndex("FoilsTypeId");

                    b.HasIndex("InteriorsAccessoryId");

                    b.HasIndex("LedlightsColorId");

                    b.HasIndex("LedlightsFormatId");

                    b.HasIndex("LedlightsPowerId");

                    b.HasIndex("LedlightsTypeId");

                    b.HasIndex("MatsTypeId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.AutoAccessories.Mats.MatsType", b =>
                {
                    b.Property<int>("MatsTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatsTypeId"), 1L, 1);

                    b.Property<string>("MatsTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MatsTypeId");

                    b.ToTable("MatsTypes");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.AutoCosmetics.CleaningAccessories.CleaningAccessory", b =>
                {
                    b.Property<int>("CleaningAccessoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CleaningAccessoryId"), 1L, 1);

                    b.Property<string>("CleaningAccessoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CleaningAccessoryId");

                    b.ToTable("CleaningAccessories");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Exterior.ExteriorsAccessory", b =>
                {
                    b.Property<int>("ExteriorAccessoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExteriorAccessoryId"), 1L, 1);

                    b.Property<string>("ExteriorAccessory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExteriorAccessoryId");

                    b.ToTable("ExteriorsAccessories");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Foil.FoilsColor", b =>
                {
                    b.Property<int>("FoilColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoilColorId"), 1L, 1);

                    b.Property<string>("FoilColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FoilColorId");

                    b.ToTable("FoilsColor");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Foil.FoilsPurpose", b =>
                {
                    b.Property<int>("FoilPurposeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoilPurposeId"), 1L, 1);

                    b.Property<string>("FoilPurpose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FoilPurposeId");

                    b.ToTable("FoilsPurpose");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Foil.FoilsType", b =>
                {
                    b.Property<int>("FoilTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoilTypeId"), 1L, 1);

                    b.Property<string>("FoilType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FoilTypeId");

                    b.ToTable("FoilsTypes");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Interior.InteriorsAccessory", b =>
                {
                    b.Property<int>("InteriorAccessoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InteriorAccessoryId"), 1L, 1);

                    b.Property<string>("InteriorAccessory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InteriorAccessoryId");

                    b.ToTable("InteriorsAccessories");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Ledlights.LedlightsColor", b =>
                {
                    b.Property<int>("LedlightsColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LedlightsColorId"), 1L, 1);

                    b.Property<string>("LedlightColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LedlightsColorId");

                    b.ToTable("LedlightsColors");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Ledlights.LedlightsFormat", b =>
                {
                    b.Property<int>("LedlightsFormatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LedlightsFormatId"), 1L, 1);

                    b.Property<string>("LedlightFormat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LedlightsFormatId");

                    b.ToTable("LedlightsFormats");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Ledlights.LedlightsPower", b =>
                {
                    b.Property<int>("LedlightsPowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LedlightsPowerId"), 1L, 1);

                    b.Property<string>("LedlightPower")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LedlightsPowerId");

                    b.ToTable("LedlightsPowers");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Ledlights.LedlightsType", b =>
                {
                    b.Property<int>("LedlightsTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LedlightsTypeId"), 1L, 1);

                    b.Property<string>("LedlightType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LedlightsTypeId");

                    b.ToTable("LedlightsTypes");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.ProductType", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductTypeId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductTypeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CartId")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CartProduct", b =>
                {
                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CartId", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("CartProduct");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<Guid>("OrderedProductsProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OrdersOrderId")
                        .HasColumnType("int");

                    b.HasKey("OrderedProductsProductId", "OrdersOrderId");

                    b.HasIndex("OrdersOrderId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("ProductUser", b =>
                {
                    b.Property<string>("LikedId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("LikedProductsProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LikedId", "LikedProductsProductId");

                    b.HasIndex("LikedProductsProductId");

                    b.ToTable("ProductUser");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Car.CarModel", b =>
                {
                    b.HasOne("ASM_Auto.Data.Models.Car.CarMake", "CarMake")
                        .WithMany("CarModels")
                        .HasForeignKey("CarMakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarMake");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Contact", b =>
                {
                    b.HasOne("ASM_Auto.Data.Models.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Order", b =>
                {
                    b.HasOne("ASM_Auto.Data.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Product", b =>
                {
                    b.HasOne("ASM_Auto.Data.Models.Car.CarMake", "CarMake")
                        .WithMany("Products")
                        .HasForeignKey("CarMakeId");

                    b.HasOne("ASM_Auto.Data.Models.Car.CarModel", "CarModel")
                        .WithMany("Products")
                        .HasForeignKey("CarModelId");

                    b.HasOne("ASM_Auto.Data.Models.Products.AutoCosmetics.CleaningAccessories.CleaningAccessory", "CleaningAccessory")
                        .WithMany("Products")
                        .HasForeignKey("CleaningAccessoryId");

                    b.HasOne("ASM_Auto.Data.Models.Products.Exterior.ExteriorsAccessory", "ExteriorsAccessory")
                        .WithMany("Products")
                        .HasForeignKey("ExteriorsAccessoryId");

                    b.HasOne("ASM_Auto.Data.Models.Products.Foil.FoilsColor", "FoilsColor")
                        .WithMany("Products")
                        .HasForeignKey("FoilsColorId");

                    b.HasOne("ASM_Auto.Data.Models.Products.Foil.FoilsPurpose", "FoilsPurpose")
                        .WithMany("Products")
                        .HasForeignKey("FoilsPurposeId");

                    b.HasOne("ASM_Auto.Data.Models.Products.Foil.FoilsType", "FoilsType")
                        .WithMany("Products")
                        .HasForeignKey("FoilsTypeId");

                    b.HasOne("ASM_Auto.Data.Models.Products.Interior.InteriorsAccessory", "InteriorsAccessory")
                        .WithMany("Products")
                        .HasForeignKey("InteriorsAccessoryId");

                    b.HasOne("ASM_Auto.Data.Models.Products.Ledlights.LedlightsColor", "LedlightsColor")
                        .WithMany("Products")
                        .HasForeignKey("LedlightsColorId");

                    b.HasOne("ASM_Auto.Data.Models.Products.Ledlights.LedlightsFormat", "LedlightsFormat")
                        .WithMany("Products")
                        .HasForeignKey("LedlightsFormatId");

                    b.HasOne("ASM_Auto.Data.Models.Products.Ledlights.LedlightsPower", "LedlightsPower")
                        .WithMany("Products")
                        .HasForeignKey("LedlightsPowerId");

                    b.HasOne("ASM_Auto.Data.Models.Products.Ledlights.LedlightsType", "LedlightsType")
                        .WithMany("Products")
                        .HasForeignKey("LedlightsTypeId");

                    b.HasOne("ASM_Auto.Data.Models.Products.AutoAccessories.Mats.MatsType", null)
                        .WithMany("Products")
                        .HasForeignKey("MatsTypeId");

                    b.HasOne("ASM_Auto.Data.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarMake");

                    b.Navigation("CarModel");

                    b.Navigation("CleaningAccessory");

                    b.Navigation("ExteriorsAccessory");

                    b.Navigation("FoilsColor");

                    b.Navigation("FoilsPurpose");

                    b.Navigation("FoilsType");

                    b.Navigation("InteriorsAccessory");

                    b.Navigation("LedlightsColor");

                    b.Navigation("LedlightsFormat");

                    b.Navigation("LedlightsPower");

                    b.Navigation("LedlightsType");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.ProductType", b =>
                {
                    b.HasOne("ASM_Auto.Data.Models.Category", "Category")
                        .WithMany("Types")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.User", b =>
                {
                    b.HasOne("ASM_Auto.Data.Models.Cart", "Cart")
                        .WithOne("User")
                        .HasForeignKey("ASM_Auto.Data.Models.User", "CartId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("CartProduct", b =>
                {
                    b.HasOne("ASM_Auto.Data.Models.Cart", null)
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_Auto.Data.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ASM_Auto.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ASM_Auto.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_Auto.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ASM_Auto.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("ASM_Auto.Data.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("OrderedProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_Auto.Data.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductUser", b =>
                {
                    b.HasOne("ASM_Auto.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("LikedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASM_Auto.Data.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("LikedProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Car.CarMake", b =>
                {
                    b.Navigation("CarModels");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Car.CarModel", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Cart", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Category", b =>
                {
                    b.Navigation("Types");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.AutoAccessories.Mats.MatsType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.AutoCosmetics.CleaningAccessories.CleaningAccessory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Exterior.ExteriorsAccessory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Foil.FoilsColor", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Foil.FoilsPurpose", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Foil.FoilsType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Interior.InteriorsAccessory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Ledlights.LedlightsColor", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Ledlights.LedlightsFormat", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Ledlights.LedlightsPower", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.Products.Ledlights.LedlightsType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ASM_Auto.Data.Models.User", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}