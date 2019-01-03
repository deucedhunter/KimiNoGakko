using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KimiNoGakko.Migrations
{
    public partial class ChangeNameOfTableInstructorToEmplyee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Instructor_InstructorID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Instructor_InstructorID",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Presence_Instructor_InstructorID",
                table: "Presence");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.RenameColumn(
                name: "InstructorID",
                table: "Presence",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Presence_InstructorID",
                table: "Presence",
                newName: "IX_Presence_EmployeeID");

            migrationBuilder.RenameColumn(
                name: "InstructorID",
                table: "Grade",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_InstructorID",
                table: "Grade",
                newName: "IX_Grade_EmployeeID");

            migrationBuilder.RenameColumn(
                name: "InstructorID",
                table: "Course",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Course_InstructorID",
                table: "Course",
                newName: "IX_Course_EmployeeID");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    FirstMidName = table.Column<string>(maxLength: 60, nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Pesel = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Employee_EmployeeID",
                table: "Course",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Employee_EmployeeID",
                table: "Grade",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Presence_Employee_EmployeeID",
                table: "Presence",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Employee_EmployeeID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Employee_EmployeeID",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Presence_Employee_EmployeeID",
                table: "Presence");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Presence",
                newName: "InstructorID");

            migrationBuilder.RenameIndex(
                name: "IX_Presence_EmployeeID",
                table: "Presence",
                newName: "IX_Presence_InstructorID");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Grade",
                newName: "InstructorID");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_EmployeeID",
                table: "Grade",
                newName: "IX_Grade_InstructorID");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Course",
                newName: "InstructorID");

            migrationBuilder.RenameIndex(
                name: "IX_Course_EmployeeID",
                table: "Course",
                newName: "IX_Course_InstructorID");

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    FirstMidName = table.Column<string>(maxLength: 60, nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Pesel = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Instructor_InstructorID",
                table: "Course",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Instructor_InstructorID",
                table: "Grade",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Presence_Instructor_InstructorID",
                table: "Presence",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
