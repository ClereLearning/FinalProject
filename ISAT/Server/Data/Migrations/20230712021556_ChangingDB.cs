using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISAT.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "ISAT",
                table: "Interview",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "ISAT",
                table: "Interview");
        }
    }
}
