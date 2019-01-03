using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KimiNoGakko.Migrations
{
    public partial class ChangePresenceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presence_Instructor_InstructorId",
                table: "Presence");

            migrationBuilder.DropForeignKey(
                name: "FK_Presence_Student_StudentId",
                table: "Presence");

            migrationBuilder.DropForeignKey(
                name: "FK_Presence_Subject_SubjectId",
                table: "Presence");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Presence",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "Presence",
                newName: "InstructorID");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Presence",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_Presence_StudentId",
                table: "Presence",
                newName: "IX_Presence_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Presence_InstructorId",
                table: "Presence",
                newName: "IX_Presence_InstructorID");

            migrationBuilder.RenameIndex(
                name: "IX_Presence_SubjectId",
                table: "Presence",
                newName: "IX_Presence_CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Presence_Subject_CourseID",
                table: "Presence",
                column: "CourseID",
                principalTable: "Subject",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Presence_Instructor_InstructorID",
                table: "Presence",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Presence_Student_StudentID",
                table: "Presence",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presence_Subject_CourseID",
                table: "Presence");

            migrationBuilder.DropForeignKey(
                name: "FK_Presence_Instructor_InstructorID",
                table: "Presence");

            migrationBuilder.DropForeignKey(
                name: "FK_Presence_Student_StudentID",
                table: "Presence");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Presence",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "InstructorID",
                table: "Presence",
                newName: "InstructorId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Presence",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Presence_StudentID",
                table: "Presence",
                newName: "IX_Presence_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Presence_InstructorID",
                table: "Presence",
                newName: "IX_Presence_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Presence_CourseID",
                table: "Presence",
                newName: "IX_Presence_SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Presence_Instructor_InstructorId",
                table: "Presence",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Presence_Student_StudentId",
                table: "Presence",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Presence_Subject_SubjectId",
                table: "Presence",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
