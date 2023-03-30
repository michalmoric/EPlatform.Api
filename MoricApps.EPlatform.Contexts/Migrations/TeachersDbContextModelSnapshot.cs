﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoricApps.EPlatform.Teachers.Storage;

#nullable disable

namespace MoricApps.EPlatform.Contexts.Migrations
{
    [DbContext(typeof(TeachersDbContext))]
    partial class TeachersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MoricApps.EPlatform.Teachers.Domain.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teacher");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "michamoric@interia.pl",
                            FirstName = "Michal",
                            LastName = "Moric",
                            PhoneNumber = "+48694871704",
                            Status = 0
                        });
                });

            modelBuilder.Entity("MoricApps.EPlatform.Teachers.Domain.Models.TeacherAssigment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TeacherEntityId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherEntityId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherAssigment");
                });

            modelBuilder.Entity("MoricApps.EPlatform.Teachers.Storage.Entities.TeacherAssigmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Assigments");
                });

            modelBuilder.Entity("MoricApps.EPlatform.Teachers.Storage.Entities.TeacherEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("MoricApps.EPlatform.Teachers.Domain.Models.TeacherAssigment", b =>
                {
                    b.HasOne("MoricApps.EPlatform.Teachers.Storage.Entities.TeacherEntity", null)
                        .WithMany("Assigments")
                        .HasForeignKey("TeacherEntityId");

                    b.HasOne("MoricApps.EPlatform.Teachers.Domain.Models.Teacher", "Teacher")
                        .WithMany("Assigments")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("MoricApps.EPlatform.Teachers.Storage.Entities.TeacherAssigmentEntity", b =>
                {
                    b.HasOne("MoricApps.EPlatform.Teachers.Domain.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("MoricApps.EPlatform.Teachers.Domain.Models.Teacher", b =>
                {
                    b.Navigation("Assigments");
                });

            modelBuilder.Entity("MoricApps.EPlatform.Teachers.Storage.Entities.TeacherEntity", b =>
                {
                    b.Navigation("Assigments");
                });
#pragma warning restore 612, 618
        }
    }
}
