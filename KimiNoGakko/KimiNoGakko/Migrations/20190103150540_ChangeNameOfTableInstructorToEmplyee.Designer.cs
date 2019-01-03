﻿// <auto-generated />
using KimiNoGakko.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace KimiNoGakko.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20190103150540_ChangeNameOfTableInstructorToEmplyee")]
    partial class ChangeNameOfTableInstructorToEmplyee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KimiNoGakko.Models.Class", b =>
                {
                    b.Property<int>("ClassID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(5);

                    b.Property<int>("Year");

                    b.HasKey("ClassID");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("KimiNoGakko.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeID");

                    b.Property<string>("FullName");

                    b.Property<int>("SubjectID");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("SubjectID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("KimiNoGakko.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Pesel")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("KimiNoGakko.Models.Enrollment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassID");

                    b.Property<int>("CourseID");

                    b.Property<string>("LongDescription")
                        .HasMaxLength(500);

                    b.Property<string>("ShortDescription")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("ClassID");

                    b.HasIndex("CourseID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("KimiNoGakko.Models.Grade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseID");

                    b.Property<int?>("EmployeeID");

                    b.Property<int?>("StudentID");

                    b.Property<decimal>("Value");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("StudentID");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("KimiNoGakko.Models.Presence", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseID");

                    b.Property<DateTime>("Data");

                    b.Property<int?>("EmployeeID");

                    b.Property<DateTime>("Godzina");

                    b.Property<bool>("IsPresent");

                    b.Property<int>("StudentID");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("StudentID");

                    b.ToTable("Presence");
                });

            modelBuilder.Entity("KimiNoGakko.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("ClassID");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("GudrdianPhoneNumber");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Pesel")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ClassID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("KimiNoGakko.Models.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsImportant");

                    b.Property<string>("Name");

                    b.HasKey("SubjectID");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("KimiNoGakko.Models.Course", b =>
                {
                    b.HasOne("KimiNoGakko.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KimiNoGakko.Models.Subject", "Subject")
                        .WithMany("Courses")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KimiNoGakko.Models.Enrollment", b =>
                {
                    b.HasOne("KimiNoGakko.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KimiNoGakko.Models.Course", "Course")
                        .WithOne("Enrollment")
                        .HasForeignKey("KimiNoGakko.Models.Enrollment", "CourseID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KimiNoGakko.Models.Grade", b =>
                {
                    b.HasOne("KimiNoGakko.Models.Course", "Course")
                        .WithMany("Grades")
                        .HasForeignKey("CourseID");

                    b.HasOne("KimiNoGakko.Models.Employee", "Employee")
                        .WithMany("Grades")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KimiNoGakko.Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentID");
                });

            modelBuilder.Entity("KimiNoGakko.Models.Presence", b =>
                {
                    b.HasOne("KimiNoGakko.Models.Course", "Course")
                        .WithMany("Presence")
                        .HasForeignKey("CourseID");

                    b.HasOne("KimiNoGakko.Models.Employee", "Employee")
                        .WithMany("Presence")
                        .HasForeignKey("EmployeeID");

                    b.HasOne("KimiNoGakko.Models.Student", "Student")
                        .WithMany("Presence")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KimiNoGakko.Models.Student", b =>
                {
                    b.HasOne("KimiNoGakko.Models.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
