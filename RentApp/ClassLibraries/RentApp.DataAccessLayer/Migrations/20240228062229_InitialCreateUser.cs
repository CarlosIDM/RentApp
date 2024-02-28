using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RolId",
                table: "Users",
                newName: "RolesId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RolId",
                table: "Users",
                newName: "IX_Users_RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolesId",
                table: "Users",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolesId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "Users",
                newName: "RolId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RolesId",
                table: "Users",
                newName: "IX_Users_RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolId",
                table: "Users",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
