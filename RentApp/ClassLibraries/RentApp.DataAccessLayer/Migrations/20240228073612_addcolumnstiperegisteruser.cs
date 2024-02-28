using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnstiperegisteruser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegisterUser",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisterUser",
                table: "Users");
        }
    }
}
