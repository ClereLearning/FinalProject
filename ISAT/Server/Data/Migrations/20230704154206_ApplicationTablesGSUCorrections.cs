using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISAT.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationTablesGSUCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersTypes",
                schema: "ISAT",
                table: "UsersTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SexualOrientations",
                schema: "ISAT",
                table: "SexualOrientations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genders",
                schema: "ISAT",
                table: "Genders");

            migrationBuilder.RenameTable(
                name: "UsersTypes",
                schema: "ISAT",
                newName: "UsersType",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "SexualOrientations",
                schema: "ISAT",
                newName: "SexualOrientation",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "Genders",
                schema: "ISAT",
                newName: "Gender",
                newSchema: "ISAT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersType",
                schema: "ISAT",
                table: "UsersType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SexualOrientation",
                schema: "ISAT",
                table: "SexualOrientation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gender",
                schema: "ISAT",
                table: "Gender",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersType",
                schema: "ISAT",
                table: "UsersType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SexualOrientation",
                schema: "ISAT",
                table: "SexualOrientation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gender",
                schema: "ISAT",
                table: "Gender");

            migrationBuilder.RenameTable(
                name: "UsersType",
                schema: "ISAT",
                newName: "UsersTypes",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "SexualOrientation",
                schema: "ISAT",
                newName: "SexualOrientations",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "Gender",
                schema: "ISAT",
                newName: "Genders",
                newSchema: "ISAT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersTypes",
                schema: "ISAT",
                table: "UsersTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SexualOrientations",
                schema: "ISAT",
                table: "SexualOrientations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genders",
                schema: "ISAT",
                table: "Genders",
                column: "Id");
        }
    }
}
