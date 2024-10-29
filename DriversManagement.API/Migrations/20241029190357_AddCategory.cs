using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriversManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "B");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Drivers");
        }
    }
}
