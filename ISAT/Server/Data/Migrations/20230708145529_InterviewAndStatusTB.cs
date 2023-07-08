using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISAT.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class InterviewAndStatusTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterviewStatus",
                schema: "ISAT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interview",
                schema: "ISAT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IntervieweeId = table.Column<int>(type: "int", nullable: false),
                    InterviewStatusId = table.Column<int>(type: "int", nullable: false),
                    Emailed = table.Column<bool>(type: "bit", nullable: false),
                    EmailToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interview_InterviewStatus_InterviewStatusId",
                        column: x => x.InterviewStatusId,
                        principalSchema: "ISAT",
                        principalTable: "InterviewStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interview_Interviewee_IntervieweeId",
                        column: x => x.IntervieweeId,
                        principalSchema: "ISAT",
                        principalTable: "Interviewee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interview_IntervieweeId",
                schema: "ISAT",
                table: "Interview",
                column: "IntervieweeId");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewStatusId",
                schema: "ISAT",
                table: "Interview",
                column: "InterviewStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interview",
                schema: "ISAT");

            migrationBuilder.DropTable(
                name: "InterviewStatus",
                schema: "ISAT");
        }
    }
}
