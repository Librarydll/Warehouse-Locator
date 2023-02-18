﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Warehouse.Infrastructure.Data;

#nullable disable

namespace Warehouse.Infrastructure.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Warehouse.Domain.Models.AnotherExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsAdditional")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("AnotherExpenses");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Brigade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Brigades");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("IncomeDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.IncomeItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Count")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IncomeId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("IncomeId");

                    b.HasIndex("MaterialId");

                    b.ToTable("IncomeItems");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<int>("MaterialCategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("SelfPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MaterialCategoryId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.MaterialCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MaterialCategories");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.MaterialExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Count")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsAdditional")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("MaterialExpenses");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.MaterialWarehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Count")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("CurrentSelfPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("LastSelfPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.ToTable("MaterialWarehouses");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BatchNumber")
                        .HasColumnType("longtext");

                    b.Property<double>("Count")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<int>("ReadyProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("SelfPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ReadyProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("DefectCount")
                        .HasColumnType("double");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<double>("ReturnCount")
                        .HasColumnType("double");

                    b.Property<double>("UsingCount")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Outcome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<DateTime>("OutcomeDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Outcomes");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.OutcomeItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Count")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int?>("OutcomeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("OutcomeId");

                    b.ToTable("OutcomeItems");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.ReadyProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ReadyProducts");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.ReadyProductWarehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BatchNumber")
                        .HasColumnType("longtext");

                    b.Property<double>("Count")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<int>("ReadyProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReadyProductId");

                    b.ToTable("ReadyProductWarehouses");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<int>("ReadyProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReadyProductId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.RecipeItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Count")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("LastUpdatedAt")
                        .HasColumnType("date");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeItems");
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
                    b.HasOne("Warehouse.Domain.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.ApplicationUser", null)
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

                    b.HasOne("Warehouse.Domain.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Warehouse.Domain.Models.AnotherExpense", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.Order", "Order")
                        .WithMany("AnotherExpenses")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Brigade", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.Order", null)
                        .WithMany("Brigades")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Income", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.IncomeItem", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.Income", "Income")
                        .WithMany("IncomeItems")
                        .HasForeignKey("IncomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse.Domain.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Income");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Material", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.MaterialCategory", "MaterialCategory")
                        .WithMany("Materials")
                        .HasForeignKey("MaterialCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaterialCategory");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.MaterialExpense", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse.Domain.Models.Order", "Order")
                        .WithMany("MaterialExpenses")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse.Domain.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.MaterialWarehouse", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Order", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.ReadyProduct", "ReadyProduct")
                        .WithMany()
                        .HasForeignKey("ReadyProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse.Domain.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReadyProduct");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.OrderItem", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse.Domain.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Outcome", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.OutcomeItem", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse.Domain.Models.Outcome", null)
                        .WithMany("OutcomeItems")
                        .HasForeignKey("OutcomeId");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.ReadyProductWarehouse", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.ReadyProduct", "ReadyProduct")
                        .WithMany()
                        .HasForeignKey("ReadyProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReadyProduct");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Recipe", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.ReadyProduct", "ReadyProduct")
                        .WithMany()
                        .HasForeignKey("ReadyProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReadyProduct");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.RecipeItem", b =>
                {
                    b.HasOne("Warehouse.Domain.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse.Domain.Models.Recipe", "Recipe")
                        .WithMany("RecipeItems")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Income", b =>
                {
                    b.Navigation("IncomeItems");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.MaterialCategory", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Order", b =>
                {
                    b.Navigation("AnotherExpenses");

                    b.Navigation("Brigades");

                    b.Navigation("MaterialExpenses");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Outcome", b =>
                {
                    b.Navigation("OutcomeItems");
                });

            modelBuilder.Entity("Warehouse.Domain.Models.Recipe", b =>
                {
                    b.Navigation("RecipeItems");
                });
#pragma warning restore 612, 618
        }
    }
}
