﻿// <auto-generated />
using System;
using ElectronicJournal.Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ElectronicJournal.Infrastructure.Migrations
{
    [DbContext(typeof(ElectronicJornalDbContext))]
    partial class ElectronicJornalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Attendances", (string)null);
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

                    b.ToTable("Grades", (string)null);
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Parent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Parents", (string)null);
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

                    b.ToTable("Schedules", (string)null);
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("Schools", (string)null);
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.SchoolClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SchoolClass", (string)null);
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<Guid>("ShoolClassId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShoolClassId");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Subjects", (string)null);
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AcademicDegree")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<Guid>("SchollId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SchollId");

                    b.ToTable("Teachers", (string)null);
                });

            modelBuilder.Entity("ParentStudent", b =>
                {
                    b.Property<Guid>("ParentsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uuid");

                    b.HasKey("ParentsId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("StudentParents", (string)null);
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
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Parent", b =>
                {
                    b.OwnsOne("ElectronicJournal.Domain.ValueObject.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("ParentId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("MiddleName")
                                .HasColumnType("text");

                            b1.HasKey("ParentId");

                            b1.ToTable("Parents");

                            b1.WithOwner()
                                .HasForeignKey("ParentId");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
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
                        .OnDelete(DeleteBehavior.Restrict)
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
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("School");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Student", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Entites.SchoolClass", "SchoolClass")
                        .WithMany("Students")
                        .HasForeignKey("ShoolClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("ElectronicJournal.Domain.ValueObject.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("StudentId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("MiddleName")
                                .HasColumnType("text");

                            b1.HasKey("StudentId");

                            b1.ToTable("Students");

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });

                    b.Navigation("FullName")
                        .IsRequired();

                    b.Navigation("SchoolClass");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Subject", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Entites.Teacher", "Teacher")
                        .WithMany("Subjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Teacher", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Entites.School", "School")
                        .WithMany("Teachers")
                        .HasForeignKey("SchollId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("ElectronicJournal.Domain.ValueObject.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("TeacherId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("MiddleName")
                                .HasColumnType("text");

                            b1.HasKey("TeacherId");

                            b1.ToTable("Teachers");

                            b1.WithOwner()
                                .HasForeignKey("TeacherId");
                        });

                    b.Navigation("FullName")
                        .IsRequired();

                    b.Navigation("School");
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

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Student", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Grades");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Entites.Subject", b =>
                {
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
