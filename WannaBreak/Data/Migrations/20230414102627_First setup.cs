using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WannaBreak.Migrations
{
    /// <inheritdoc />
    public partial class Firstsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "VacancyTypes",
                columns: table => new
                {
                    VacancyTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacancyTitel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyTypes", x => x.VacancyTypeID);
                });

            migrationBuilder.CreateTable(
                name: "VacancyLists",
                columns: table => new
                {
                    VacancyListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_EmployeeID = table.Column<int>(type: "int", nullable: false),
                    FK_VacancyTypeID = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stop = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyLists", x => x.VacancyListID);
                    table.ForeignKey(
                        name: "FK_VacancyLists_Employees_FK_EmployeeID",
                        column: x => x.FK_EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancyLists_VacancyTypes_FK_VacancyTypeID",
                        column: x => x.FK_VacancyTypeID,
                        principalTable: "VacancyTypes",
                        principalColumn: "VacancyTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VacancyLists_FK_EmployeeID",
                table: "VacancyLists",
                column: "FK_EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyLists_FK_VacancyTypeID",
                table: "VacancyLists",
                column: "FK_VacancyTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacancyLists");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "VacancyTypes");
        }
    }
}
