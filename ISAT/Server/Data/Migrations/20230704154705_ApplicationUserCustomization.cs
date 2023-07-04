using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISAT.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUserCustomization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "ISAT",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                schema: "ISAT",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Inactive",
                schema: "ISAT",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "ISAT",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SexualOrientationId",
                schema: "ISAT",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialName",
                schema: "ISAT",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UsersTypeId",
                schema: "ISAT",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                schema: "ISAT",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SexualOrientationId",
                schema: "ISAT",
                table: "AspNetUsers",
                column: "SexualOrientationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UsersTypeId",
                schema: "ISAT",
                table: "AspNetUsers",
                column: "UsersTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Gender_GenderId",
                schema: "ISAT",
                table: "AspNetUsers",
                column: "GenderId",
                principalSchema: "ISAT",
                principalTable: "Gender",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SexualOrientation_SexualOrientationId",
                schema: "ISAT",
                table: "AspNetUsers",
                column: "SexualOrientationId",
                principalSchema: "ISAT",
                principalTable: "SexualOrientation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UsersType_UsersTypeId",
                schema: "ISAT",
                table: "AspNetUsers",
                column: "UsersTypeId",
                principalSchema: "ISAT",
                principalTable: "UsersType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gender_GenderId",
                schema: "ISAT",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SexualOrientation_SexualOrientationId",
                schema: "ISAT",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UsersType_UsersTypeId",
                schema: "ISAT",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GenderId",
                schema: "ISAT",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SexualOrientationId",
                schema: "ISAT",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UsersTypeId",
                schema: "ISAT",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "ISAT",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GenderId",
                schema: "ISAT",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Inactive",
                schema: "ISAT",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "ISAT",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SexualOrientationId",
                schema: "ISAT",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SocialName",
                schema: "ISAT",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UsersTypeId",
                schema: "ISAT",
                table: "AspNetUsers");
        }
    }
}
