﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SPCalculator.Data.Context;

#nullable disable

namespace SPCalculator.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SPCalculator.Entity.Entities.Function", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FunctionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Functions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c33f282a-664b-4042-b967-f544ecf86b79"),
                            CreatedDate = new DateTime(2023, 7, 21, 19, 8, 19, 86, DateTimeKind.Local).AddTicks(6604),
                            FunctionName = "Ekran Ekleme",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("174f50fe-10cc-4b07-943e-023b0a0a47c6"),
                            CreatedDate = new DateTime(2023, 7, 21, 19, 8, 19, 86, DateTimeKind.Local).AddTicks(6608),
                            FunctionName = "Ekran Güncelleme",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("SPCalculator.Entity.Entities.Parameter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ParameterDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParameterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParameterPoint")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Parameters");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3c22b6b0-45c7-455e-9bca-da2c051b5011"),
                            CreatedDate = new DateTime(2023, 7, 21, 19, 8, 19, 86, DateTimeKind.Local).AddTicks(6769),
                            IsDeleted = false,
                            ParameterDesc = "Pop-up Ekran Ekleme",
                            ParameterName = "Ekran Ekleme",
                            ParameterPoint = 4
                        },
                        new
                        {
                            Id = new Guid("4461add9-168b-468f-8d8a-bc333690d8b3"),
                            CreatedDate = new DateTime(2023, 7, 21, 19, 8, 19, 86, DateTimeKind.Local).AddTicks(6772),
                            IsDeleted = false,
                            ParameterDesc = "Pop-up Ekran Güncelleme",
                            ParameterName = "Ekran Güncelleme",
                            ParameterPoint = 2
                        });
                });

            modelBuilder.Entity("SPCalculator.Entity.Entities.Sprint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("BasePoint")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DifficultyLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FunctionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ItemNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ParameterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SprintName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VersionInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.HasIndex("ParameterId");

                    b.ToTable("Sprints");

                    b.HasData(
                        new
                        {
                            Id = new Guid("53df0cc3-e8c0-47cb-8977-5f4b12c07da7"),
                            BasePoint = 0.0,
                            CreatedDate = new DateTime(2023, 7, 21, 19, 8, 19, 86, DateTimeKind.Local).AddTicks(6870),
                            DifficultyLevel = "Easy",
                            FunctionId = new Guid("c33f282a-664b-4042-b967-f544ecf86b79"),
                            IsDeleted = false,
                            ItemNo = "EES-48940",
                            ParameterId = new Guid("3c22b6b0-45c7-455e-9bca-da2c051b5011"),
                            SprintName = "Sprint 1",
                            VersionInfo = "EES - 4.13-2023.R10 05/30"
                        },
                        new
                        {
                            Id = new Guid("7f35feb9-f7f3-41a4-abb6-f5ed5ec0e8bd"),
                            BasePoint = 0.0,
                            CreatedDate = new DateTime(2023, 7, 21, 19, 8, 19, 86, DateTimeKind.Local).AddTicks(6874),
                            DifficultyLevel = "Easy",
                            FunctionId = new Guid("174f50fe-10cc-4b07-943e-023b0a0a47c6"),
                            IsDeleted = false,
                            ItemNo = "EES-48940",
                            ParameterId = new Guid("4461add9-168b-468f-8d8a-bc333690d8b3"),
                            SprintName = "Sprint 2",
                            VersionInfo = "EES - 4.13-2023.R10 05/30"
                        });
                });

            modelBuilder.Entity("SPCalculator.Entity.Entities.SprintFunction", b =>
                {
                    b.Property<Guid>("SprintId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FunctionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SprintId", "FunctionId");

                    b.HasIndex("FunctionId");

                    b.ToTable("SprintFunctions");
                });

            modelBuilder.Entity("SPCalculator.Entity.Entities.SprintParameter", b =>
                {
                    b.Property<Guid>("SprintId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ParameterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SprintId", "ParameterId");

                    b.HasIndex("ParameterId");

                    b.ToTable("SprintParameters");
                });

            modelBuilder.Entity("SPCalculator.Entity.Entities.Sprint", b =>
                {
                    b.HasOne("SPCalculator.Entity.Entities.Function", "Function")
                        .WithMany("Sprints")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SPCalculator.Entity.Entities.Parameter", "Parameter")
                        .WithMany("Sprints")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Function");

                    b.Navigation("Parameter");
                });

            modelBuilder.Entity("SPCalculator.Entity.Entities.SprintFunction", b =>
                {
                    b.HasOne("SPCalculator.Entity.Entities.Function", "Function")
                        .WithMany("SprintFunctions")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SPCalculator.Entity.Entities.Sprint", "Sprint")
                        .WithMany("SprintFunctions")
                        .HasForeignKey("SprintId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Function");

                    b.Navigation("Sprint");
                });

            modelBuilder.Entity("SPCalculator.Entity.Entities.SprintParameter", b =>
                {
                    b.HasOne("SPCalculator.Entity.Entities.Parameter", "Parameter")
                        .WithMany("SprintParameters")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SPCalculator.Entity.Entities.Sprint", "Sprint")
                        .WithMany("SprintParameters")
                        .HasForeignKey("SprintId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Parameter");

                    b.Navigation("Sprint");
                });

            modelBuilder.Entity("SPCalculator.Entity.Entities.Function", b =>
                {
                    b.Navigation("SprintFunctions");

                    b.Navigation("Sprints");
                });

            modelBuilder.Entity("SPCalculator.Entity.Entities.Parameter", b =>
                {
                    b.Navigation("SprintParameters");

                    b.Navigation("Sprints");
                });

            modelBuilder.Entity("SPCalculator.Entity.Entities.Sprint", b =>
                {
                    b.Navigation("SprintFunctions");

                    b.Navigation("SprintParameters");
                });
#pragma warning restore 612, 618
        }
    }
}
