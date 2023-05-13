using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRDZSchool.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InfoRoundOfSiteMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EGEResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Russian = table.Column<float>(type: "real", nullable: false),
                    MathBase = table.Column<float>(type: "real", nullable: false),
                    MathProfi = table.Column<float>(type: "real", nullable: false),
                    History = table.Column<float>(type: "real", nullable: false),
                    SocialStudies = table.Column<float>(type: "real", nullable: false),
                    Physics = table.Column<float>(type: "real", nullable: false),
                    Chemistry = table.Column<float>(type: "real", nullable: false),
                    Geography = table.Column<float>(type: "real", nullable: false),
                    Biology = table.Column<float>(type: "real", nullable: false),
                    Informatics = table.Column<float>(type: "real", nullable: false),
                    English = table.Column<float>(type: "real", nullable: false),
                    Literature = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EGEResult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OGEResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Russian = table.Column<float>(type: "real", nullable: false),
                    Math = table.Column<float>(type: "real", nullable: false),
                    SocialStudies = table.Column<float>(type: "real", nullable: false),
                    English = table.Column<float>(type: "real", nullable: false),
                    Informatics = table.Column<float>(type: "real", nullable: false),
                    History = table.Column<float>(type: "real", nullable: false),
                    Biology = table.Column<float>(type: "real", nullable: false),
                    Chemistry = table.Column<float>(type: "real", nullable: false),
                    Geography = table.Column<float>(type: "real", nullable: false),
                    Physics = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OGEResult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "EGEResult");

            migrationBuilder.DropTable(
                name: "OGEResult");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
