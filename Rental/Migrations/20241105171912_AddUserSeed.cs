using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "Email", "FirstName", "LastName" },
            values: new[] { "Email@email.com", "John", "T" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "FirstName",
                keyValue: "John");
        }
    }
}
