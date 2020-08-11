﻿// <auto-generated />
using System;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagement.Infrastructure.Migrations
{
    [DbContext(typeof(ManagementContext))]
    [Migration("20200811042359_EmailAddress")]
    partial class EmailAddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeManagement.Core.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            FirstName = "Johnny",
                            LastName = "Donuts",
                            Salary = 2000.0
                        });
                });

            modelBuilder.Entity("EmployeeManagement.Core.Model.BenefitPolicy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChecksPerYear")
                        .HasColumnType("int");

                    b.Property<double>("DependentCostPerYear")
                        .HasColumnType("float");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("float");

                    b.Property<double>("EmployeeCostPerYear")
                        .HasColumnType("float");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LetterToDiscount")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("ID");

                    b.ToTable("BenefitPolicies");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ChecksPerYear = 0,
                            DependentCostPerYear = 500.0,
                            DiscountAmount = 0.10000000000000001,
                            EmployeeCostPerYear = 1000.0,
                            IsActive = false,
                            LetterToDiscount = "A"
                        });
                });

            modelBuilder.Entity("EmployeeManagement.Core.Model.Dependent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Relationship")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("EmployeeManagement.Core.Model.Paycheck", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BaseSalary")
                        .HasColumnType("float");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<double>("SalaryAfterDeductions")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Paychecks");
                });

            modelBuilder.Entity("EmployeeManagement.Core.Model.Dependent", b =>
                {
                    b.HasOne("EmployeeManagement.Core.Employee", null)
                        .WithMany("Dependents")
                        .HasForeignKey("EmployeeID");
                });

            modelBuilder.Entity("EmployeeManagement.Core.Model.Paycheck", b =>
                {
                    b.HasOne("EmployeeManagement.Core.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");
                });
#pragma warning restore 612, 618
        }
    }
}
