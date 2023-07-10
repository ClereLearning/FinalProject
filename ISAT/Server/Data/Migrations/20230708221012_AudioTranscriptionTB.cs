using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISAT.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AudioTranscriptionTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AudioDate",
                schema: "ISAT",
                table: "Interview",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "AudioFile",
                schema: "ISAT",
                table: "Interview",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AudioStatus",
                schema: "ISAT",
                table: "Interview",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioDate",
                schema: "ISAT",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "AudioFile",
                schema: "ISAT",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "AudioStatus",
                schema: "ISAT",
                table: "Interview");
        }
    }
}
