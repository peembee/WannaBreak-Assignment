using Microsoft.EntityFrameworkCore.Migrations;



namespace WannaBreak.Migrations
{
    /// <inheritdoc />
    public partial class addingnewcolumninVacancyListforsavingemployeeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeFullName",
                table: "VacancyLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeFullName",
                table: "VacancyLists");
        }
    }
}
