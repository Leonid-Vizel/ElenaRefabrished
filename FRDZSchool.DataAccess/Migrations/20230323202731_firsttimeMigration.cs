using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FRDZ_School_Web.Migrations
{
    /// <inheritdoc />
    public partial class firsttimeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Grade_Num = table.Column<int>(type: "int", nullable: false),
                    Grade_Index = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Academic_Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => new { x.Grade_Num, x.Grade_Index, x.Academic_Year });
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Lesson_Num = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lesson_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code_Obj = table.Column<int>(type: "int", nullable: false),
                    Date_And_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Teacher_Num = table.Column<int>(type: "int", nullable: false),
                    Home_Task = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Lesson_Num);
                });

            migrationBuilder.CreateTable(
                name: "Lesson_Student",
                columns: table => new
                {
                    Lesson_Num = table.Column<int>(type: "int", nullable: false),
                    Student_Num = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Visiting = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson_Student", x => new { x.Lesson_Num, x.Student_Num });
                });

            migrationBuilder.CreateTable(
                name: "School_Object",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Obj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Object", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Student_Num = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Student_Num);
                });

            migrationBuilder.CreateTable(
                name: "Student_Grade",
                columns: table => new
                {
                    Student_Num = table.Column<int>(type: "int", nullable: false),
                    Grade_Num = table.Column<int>(type: "int", nullable: false),
                    Grade_Index = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Academic_Year = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Grade", x => new { x.Grade_Num, x.Grade_Index, x.Academic_Year, x.Student_Num });
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Teacher_Num = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Post = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tel_Num = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Teacher_Num);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "Lesson_Student");

            migrationBuilder.DropTable(
                name: "School_Object");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Student_Grade");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
