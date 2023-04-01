using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoricApps.EPlatform.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class SmallFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assigments_Teacher_TeacherId",
                table: "Assigments");

            migrationBuilder.AddForeignKey(
                name: "FK_Assigments_Teachers_TeacherId",
                table: "Assigments",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assigments_Teachers_TeacherId",
                table: "Assigments");

            migrationBuilder.AddForeignKey(
                name: "FK_Assigments_Teacher_TeacherId",
                table: "Assigments",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
