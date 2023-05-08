using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRDZSchool.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ReturnMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fathername",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fathername",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fathername",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Fathername",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Student");
        }
    }
}
