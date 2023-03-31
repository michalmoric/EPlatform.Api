using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoricApps.EPlatform.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class AddedSoftDeleting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Email", "FirstName", "IsDeleted", "LastName", "PhoneNumber", "Status" },
                values: new object[] { 1, "michamoric@interia.pl", "Michal", false, "Moric", "+48694871704", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Teachers");

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber", "Status" },
                values: new object[] { 1, "michamoric@interia.pl", "Michal", "Moric", "+48694871704", 0 });
        }
    }
}
