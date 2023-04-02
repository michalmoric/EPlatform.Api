using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoricApps.EPlatform.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class PlzJustWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherAssigment");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherAssigment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeacherEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAssigment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherAssigment_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherAssigment_Teachers_TeacherEntityId",
                        column: x => x.TeacherEntityId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Email", "FirstName", "IsDeleted", "LastName", "PhoneNumber", "Status" },
                values: new object[] { 1, "michamoric@interia.pl", "Michal", false, "Moric", "+48694871704", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAssigment_TeacherEntityId",
                table: "TeacherAssigment",
                column: "TeacherEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAssigment_TeacherId",
                table: "TeacherAssigment",
                column: "TeacherId");
        }
    }
}
