using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectronicJournal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_SchoolClasses_SchoolClassId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_Schools_SchoolId",
                table: "SchoolClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_Teachers_TeacherId",
                table: "SchoolClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClassSubject_SchoolClasses_SchoolClassesId",
                table: "SchoolClassSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_SchoolClasses_ShoolClassId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolClasses",
                table: "SchoolClasses");

            migrationBuilder.RenameTable(
                name: "SchoolClasses",
                newName: "SchoolClass");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolClasses_TeacherId",
                table: "SchoolClass",
                newName: "IX_SchoolClass_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolClasses_SchoolId",
                table: "SchoolClass",
                newName: "IX_SchoolClass_SchoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolClass",
                table: "SchoolClass",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_SchoolClass_SchoolClassId",
                table: "Schedules",
                column: "SchoolClassId",
                principalTable: "SchoolClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClass_Schools_SchoolId",
                table: "SchoolClass",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClass_Teachers_TeacherId",
                table: "SchoolClass",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClassSubject_SchoolClass_SchoolClassesId",
                table: "SchoolClassSubject",
                column: "SchoolClassesId",
                principalTable: "SchoolClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SchoolClass_ShoolClassId",
                table: "Students",
                column: "ShoolClassId",
                principalTable: "SchoolClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_SchoolClass_SchoolClassId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClass_Schools_SchoolId",
                table: "SchoolClass");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClass_Teachers_TeacherId",
                table: "SchoolClass");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClassSubject_SchoolClass_SchoolClassesId",
                table: "SchoolClassSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_SchoolClass_ShoolClassId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolClass",
                table: "SchoolClass");

            migrationBuilder.RenameTable(
                name: "SchoolClass",
                newName: "SchoolClasses");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolClass_TeacherId",
                table: "SchoolClasses",
                newName: "IX_SchoolClasses_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_SchoolClass_SchoolId",
                table: "SchoolClasses",
                newName: "IX_SchoolClasses_SchoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolClasses",
                table: "SchoolClasses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_SchoolClasses_SchoolClassId",
                table: "Schedules",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_Schools_SchoolId",
                table: "SchoolClasses",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_Teachers_TeacherId",
                table: "SchoolClasses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClassSubject_SchoolClasses_SchoolClassesId",
                table: "SchoolClassSubject",
                column: "SchoolClassesId",
                principalTable: "SchoolClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SchoolClasses_ShoolClassId",
                table: "Students",
                column: "ShoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
