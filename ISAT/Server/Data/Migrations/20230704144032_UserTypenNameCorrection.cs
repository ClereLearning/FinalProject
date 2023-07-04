using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISAT.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserTypenNameCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_usersTypes",
                schema: "ISAT",
                table: "usersTypes");

            migrationBuilder.RenameTable(
                name: "usersTypes",
                schema: "ISAT",
                newName: "UsersTypes",
                newSchema: "ISAT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersTypes",
                schema: "ISAT",
                table: "UsersTypes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersTypes",
                schema: "ISAT",
                table: "UsersTypes");

            migrationBuilder.RenameTable(
                name: "UsersTypes",
                schema: "ISAT",
                newName: "usersTypes",
                newSchema: "ISAT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usersTypes",
                schema: "ISAT",
                table: "usersTypes",
                column: "Id");
        }
    }
}
