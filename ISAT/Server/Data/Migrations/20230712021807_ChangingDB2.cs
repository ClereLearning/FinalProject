using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISAT.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "UserToken",
                schema: "ISAT",
                newName: "UserToken",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UsersType",
                schema: "ISAT",
                newName: "UsersType",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserRole",
                schema: "ISAT",
                newName: "UserRole",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserLogin",
                schema: "ISAT",
                newName: "UserLogin",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserClaim",
                schema: "ISAT",
                newName: "UserClaim",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "ISAT",
                newName: "User",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "SexualOrientation",
                schema: "ISAT",
                newName: "SexualOrientation",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "RoleClaim",
                schema: "ISAT",
                newName: "RoleClaim",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "ISAT",
                newName: "Role",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "PersistedGrants",
                schema: "ISAT",
                newName: "PersistedGrants",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Keys",
                schema: "ISAT",
                newName: "Keys",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "InterviewStatus",
                schema: "ISAT",
                newName: "InterviewStatus",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Interviewee",
                schema: "ISAT",
                newName: "Interviewee",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Interview",
                schema: "ISAT",
                newName: "Interview",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Gender",
                schema: "ISAT",
                newName: "Gender",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "DeviceCodes",
                schema: "ISAT",
                newName: "DeviceCodes",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "ISAT",
                newName: "AspNetUsers",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "ISAT",
                newName: "AspNetRoles",
                newSchema: "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ISAT");

            migrationBuilder.RenameTable(
                name: "UserToken",
                schema: "dbo",
                newName: "UserToken",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "UsersType",
                schema: "dbo",
                newName: "UsersType",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "UserRole",
                schema: "dbo",
                newName: "UserRole",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "UserLogin",
                schema: "dbo",
                newName: "UserLogin",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "UserClaim",
                schema: "dbo",
                newName: "UserClaim",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "dbo",
                newName: "User",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "SexualOrientation",
                schema: "dbo",
                newName: "SexualOrientation",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "RoleClaim",
                schema: "dbo",
                newName: "RoleClaim",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "dbo",
                newName: "Role",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "PersistedGrants",
                schema: "dbo",
                newName: "PersistedGrants",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "Keys",
                schema: "dbo",
                newName: "Keys",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "InterviewStatus",
                schema: "dbo",
                newName: "InterviewStatus",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "Interviewee",
                schema: "dbo",
                newName: "Interviewee",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "Interview",
                schema: "dbo",
                newName: "Interview",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "Gender",
                schema: "dbo",
                newName: "Gender",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "DeviceCodes",
                schema: "dbo",
                newName: "DeviceCodes",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "dbo",
                newName: "AspNetUsers",
                newSchema: "ISAT");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "dbo",
                newName: "AspNetRoles",
                newSchema: "ISAT");
        }
    }
}
