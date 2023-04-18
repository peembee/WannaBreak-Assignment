using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WannaBreak.Migrations
{
    /// <inheritdoc />
    public partial class addingnewcolumninVacancyListforsavingvacancyTitel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VacancyNameTitel",
                table: "VacancyLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VacancyNameTitel",
                table: "VacancyLists");
        }
    }
}
