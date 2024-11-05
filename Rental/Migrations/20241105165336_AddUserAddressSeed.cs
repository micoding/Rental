using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rental.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAddressSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "tmp@tmp.com", "First Name", "Last Name" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Street", "UserId", "ZipCode" },
                values: new object[] { 1, "First City", "First Country", "First Street", 1, "90-999" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
