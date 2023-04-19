using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRDZSchool.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class editDateTimeErrorMgration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AcademYear",
                table: "Grade",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AcademYear",
                table: "Grade",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
