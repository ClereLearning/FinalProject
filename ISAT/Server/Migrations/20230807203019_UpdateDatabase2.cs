using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ISAT.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Gender",
                keyColumn: "Id",
                keyValue: new Guid("6792559f-eb77-41af-9c45-ad35fbfc1350"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Gender",
                keyColumn: "Id",
                keyValue: new Guid("d01c4b42-aefb-4e31-9b03-7452705aa369"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "SexualOrientation",
                keyColumn: "Id",
                keyValue: new Guid("3315af7d-70e4-4ddd-a838-ee99f401e15e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "SexualOrientation",
                keyColumn: "Id",
                keyValue: new Guid("b17ae524-3747-45d8-9517-95cb7ca79025"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UsersType",
                keyColumn: "Id",
                keyValue: new Guid("3309a5e8-23eb-4a89-b594-db0f7561212e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UsersType",
                keyColumn: "Id",
                keyValue: new Guid("4e7bdfa8-0f70-4015-b820-ec22ce22083b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UsersType",
                keyColumn: "Id",
                keyValue: new Guid("7197c2cf-207b-4550-90e2-89f676fddc73"));

            migrationBuilder.AddColumn<Guid>(
                name: "InterviewerId",
                schema: "dbo",
                table: "Interview",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Gender",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("061298d2-9a7c-43d0-ae5f-ca77bf5f64e2"), "Was not asked", "Not asked" },
                    { new Guid("3dfa3014-20dd-4ca8-aefc-476635d27186"), "Asked but, not informed", "Not Informed" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "SexualOrientation",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("10526339-0329-48f9-b2d8-6dc4ce3ee34b"), "Was not asked", "Not asked" },
                    { new Guid("5bc47d05-745d-49a8-a12f-545d53230978"), "Asked but, not informed", "Not Informed" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UsersType",
                columns: new[] { "Id", "Deletable", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("55132f64-4e77-4cce-a565-9f3c315b92e0"), false, "Researcher Users", "Researcher" },
                    { new Guid("a8955dd5-a326-4223-abd0-78d0e11bbe53"), false, "Interviewer Users", "Interviewer" },
                    { new Guid("f691dbf1-e126-431c-b7a3-1bc23ae070d6"), false, "Administrative Users", "Administrative" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Gender",
                keyColumn: "Id",
                keyValue: new Guid("061298d2-9a7c-43d0-ae5f-ca77bf5f64e2"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Gender",
                keyColumn: "Id",
                keyValue: new Guid("3dfa3014-20dd-4ca8-aefc-476635d27186"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "SexualOrientation",
                keyColumn: "Id",
                keyValue: new Guid("10526339-0329-48f9-b2d8-6dc4ce3ee34b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "SexualOrientation",
                keyColumn: "Id",
                keyValue: new Guid("5bc47d05-745d-49a8-a12f-545d53230978"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UsersType",
                keyColumn: "Id",
                keyValue: new Guid("55132f64-4e77-4cce-a565-9f3c315b92e0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UsersType",
                keyColumn: "Id",
                keyValue: new Guid("a8955dd5-a326-4223-abd0-78d0e11bbe53"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UsersType",
                keyColumn: "Id",
                keyValue: new Guid("f691dbf1-e126-431c-b7a3-1bc23ae070d6"));

            migrationBuilder.DropColumn(
                name: "InterviewerId",
                schema: "dbo",
                table: "Interview");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Gender",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("6792559f-eb77-41af-9c45-ad35fbfc1350"), "Was not asked", "Not asked" },
                    { new Guid("d01c4b42-aefb-4e31-9b03-7452705aa369"), "Asked but, not informed", "Not Informed" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "SexualOrientation",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3315af7d-70e4-4ddd-a838-ee99f401e15e"), "Was not asked", "Not asked" },
                    { new Guid("b17ae524-3747-45d8-9517-95cb7ca79025"), "Asked but, not informed", "Not Informed" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UsersType",
                columns: new[] { "Id", "Deletable", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3309a5e8-23eb-4a89-b594-db0f7561212e"), false, "Administrative Users", "Administrative" },
                    { new Guid("4e7bdfa8-0f70-4015-b820-ec22ce22083b"), false, "Interviewer Users", "Interviewer" },
                    { new Guid("7197c2cf-207b-4550-90e2-89f676fddc73"), false, "Researcher Users", "Researcher" }
                });
        }
    }
}
