﻿// <auto-generated />
using System;
using ElectronicJournal.Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ElectronicJournal.Infrastructure.Migrations
{
    [DbContext(typeof(ElectronicJornalDbContext))]
    [Migration("20241206083912_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("SchoolClassId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.HasIndex("SchoolClassId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.SchoolClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SchoolClasses");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateofBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasDiscriminator().HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ParentStudent", b =>
                {
                    b.Property<Guid>("ParentsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uuid");

                    b.HasKey("ParentsId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("ParentStudent");
                });

            modelBuilder.Entity("SchoolClassSubject", b =>
                {
                    b.Property<Guid>("SchoolClassesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubjectsId")
                        .HasColumnType("uuid");

                    b.HasKey("SchoolClassesId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("SchoolClassSubject");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Parent", b =>
                {
                    b.HasBaseType("ElectronicJournal.Domain.Entites.User");

                    b.HasDiscriminator().HasValue("Parent");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Student", b =>
                {
                    b.HasBaseType("ElectronicJournal.Domain.Entites.User");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SchoolClassId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ShoolClassId")
                        .HasColumnType("uuid");

                    b.HasIndex("SchoolClassId");

                    b.ToTable("User", t =>
                        {
                            t.Property("Description")
                                .HasColumnName("Student_Description");
                        });

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Teacher", b =>
                {
                    b.HasBaseType("ElectronicJournal.Domain.Entites.User");

                    b.Property<string>("AcademicDegree")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SchollId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("uuid");

                    b.HasIndex("SchoolId");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Attendance", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Entites.Student", "Student")
                        .WithMany("Attendances")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Grade", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Entites.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Domain.Entites.Subject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Schedule", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Entites.SchoolClass", "SchoolClass")
                        .WithMany("Schedules")
                        .HasForeignKey("SchoolClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Domain.Entites.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolClass");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.SchoolClass", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Entites.School", "School")
                        .WithMany("SchoolClasses")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Domain.Entites.Teacher", "Teacher")
                        .WithMany("SchoolClasses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Subject", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Entites.Teacher", "Teacher")
                        .WithMany("Subjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.User", b =>
                {
                    b.OwnsOne("ElectronicJournal.Domain.ValueObject.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("MiddleName")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
                });

            modelBuilder.Entity("ParentStudent", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Entites.Parent", null)
                        .WithMany()
                        .HasForeignKey("ParentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Domain.Entites.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolClassSubject", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Entites.SchoolClass", null)
                        .WithMany()
                        .HasForeignKey("SchoolClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Domain.Entites.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Student", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Entites.SchoolClass", "SchoolClass")
                        .WithMany("Students")
                        .HasForeignKey("SchoolClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolClass");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Teacher", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Entites.School", "School")
                        .WithMany("Teachers")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.School", b =>
                {
                    b.Navigation("SchoolClasses");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.SchoolClass", b =>
                {
                    b.Navigation("Schedules");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Subject", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Student", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Grades");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Teacher", b =>
                {
                    b.Navigation("SchoolClasses");

                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
