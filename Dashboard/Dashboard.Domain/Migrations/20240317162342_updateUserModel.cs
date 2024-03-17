using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard.Domain.Migrations
{
    /// <inheritdoc />
    public partial class updateUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "User",
                newName: "SaltPassword");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "User",
                newName: "HashPassword");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SaltPassword",
                table: "User",
                newName: "PasswordSalt");

            migrationBuilder.RenameColumn(
                name: "HashPassword",
                table: "User",
                newName: "PasswordHash");
        }
    }
}
