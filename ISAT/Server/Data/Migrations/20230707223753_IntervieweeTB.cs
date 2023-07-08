using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISAT.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class IntervieweeTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interviewee",
                schema: "ISAT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    SexualOrientationId = table.Column<int>(type: "int", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviewee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interviewee_Gender_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "ISAT",
                        principalTable: "Gender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Interviewee_SexualOrientation_SexualOrientationId",
                        column: x => x.SexualOrientationId,
                        principalSchema: "ISAT",
                        principalTable: "SexualOrientation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interviewee_GenderId",
                schema: "ISAT",
                table: "Interviewee",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviewee_SexualOrientationId",
                schema: "ISAT",
                table: "Interviewee",
                column: "SexualOrientationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interviewee",
                schema: "ISAT");
        }
    }
}
