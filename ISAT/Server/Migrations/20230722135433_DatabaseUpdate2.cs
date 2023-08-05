using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ISAT.Server.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Gender",
                keyColumn: "Id",
                keyValue: new Guid("09d10c51-6fb6-4d49-8f07-e979860edd09"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Gender",
                keyColumn: "Id",
                keyValue: new Guid("4a18f040-73ef-4f92-ad30-211e969bcd91"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "SexualOrientation",
                keyColumn: "Id",
                keyValue: new Guid("01c05e00-4a46-4034-9228-5564e8b1cbee"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "SexualOrientation",
                keyColumn: "Id",
                keyValue: new Guid("e6281e5e-f5f5-4b70-9d43-c26945456915"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UsersType",
                keyColumn: "Id",
                keyValue: new Guid("0d7b112a-3179-496e-b057-4bc3339df08c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UsersType",
                keyColumn: "Id",
                keyValue: new Guid("169bfab7-5e7e-40ed-a66e-f037f09499a6"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UsersType",
                keyColumn: "Id",
                keyValue: new Guid("8b2020aa-9855-4f0a-acca-be45bbaf4aab"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Gender",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("5611edc3-99b3-4078-91ed-2847dc445fd8"), "Asked but, not informed", "Not Informed" },
                    { new Guid("b14eaf61-3585-4f5f-bc72-bfde5c833bed"), "Was not asked", "Not asked" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "SexualOrientation",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("04edb354-c321-49b9-b303-b2abddf5be0f"), "Was not asked", "Not asked" },
                    { new Guid("b01e2e3a-1683-4fdb-a65e-9342b7b9bc02"), "Asked but, not informed", "Not Informed" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UsersType",
                columns: new[] { "Id", "Deletable", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1f457829-e752-4ab7-8e49-5232a3904474"), false, "Interviewer Users", "Interviewer" },
                    { new Guid("37088b96-19ea-4eb3-9544-a876479d8d8b"), false, "Administrative Users", "Administrative" },
                    { new Guid("d4b6fd3a-9df3-40e6-ac8e-2ae6b92b6542"), false, "Researcher Users", "Researcher" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interview_IntervieweeId",
                schema: "dbo",
                table: "Interview",
                column: "IntervieweeId");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_InterviewStatusId",
                schema: "dbo",
                table: "Interview",
                column: "InterviewStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_InterviewStatus_InterviewStatusId",
                schema: "dbo",
                table: "Interview",
                column: "InterviewStatusId",
                principalSchema: "dbo",
                principalTable: "InterviewStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_Interviewee_IntervieweeId",
                schema: "dbo",
                table: "Interview",
                column: "IntervieweeId",
                principalSchema: "dbo",
                principalTable: "Interviewee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_InterviewStatus_InterviewStatusId",
                schema: "dbo",
                table: "Interview");

            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Interviewee_IntervieweeId",
                schema: "dbo",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_IntervieweeId",
                schema: "dbo",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_InterviewStatusId",
                schema: "dbo",
                table: "Interview");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Gender",
                keyColumn: "Id",
                keyValue: new Guid("5611edc3-99b3-4078-91ed-2847dc445fd8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Gender",
                keyColumn: "Id",
                keyValue: new Guid("b14eaf61-3585-4f5f-bc72-bfde5c833bed"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "SexualOrientation",
                keyColumn: "Id",
                keyValue: new Guid("04edb354-c321-49b9-b303-b2abddf5be0f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "SexualOrientation",
                keyColumn: "Id",
                keyValue: new Guid("b01e2e3a-1683-4fdb-a65e-9342b7b9bc02"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UsersType",
                keyColumn: "Id",
                keyValue: new Guid("1f457829-e752-4ab7-8e49-5232a3904474"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UsersType",
                keyColumn: "Id",
                keyValue: new Guid("37088b96-19ea-4eb3-9544-a876479d8d8b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UsersType",
                keyColumn: "Id",
                keyValue: new Guid("d4b6fd3a-9df3-40e6-ac8e-2ae6b92b6542"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Gender",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("09d10c51-6fb6-4d49-8f07-e979860edd09"), "Was not asked", "Not asked" },
                    { new Guid("4a18f040-73ef-4f92-ad30-211e969bcd91"), "Asked but, not informed", "Not Informed" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "SexualOrientation",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("01c05e00-4a46-4034-9228-5564e8b1cbee"), "Asked but, not informed", "Not Informed" },
                    { new Guid("e6281e5e-f5f5-4b70-9d43-c26945456915"), "Was not asked", "Not asked" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UsersType",
                columns: new[] { "Id", "Deletable", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0d7b112a-3179-496e-b057-4bc3339df08c"), false, "Interviewer Users", "Interviewer" },
                    { new Guid("169bfab7-5e7e-40ed-a66e-f037f09499a6"), false, "Administrative Users", "Administrative" },
                    { new Guid("8b2020aa-9855-4f0a-acca-be45bbaf4aab"), false, "Researcher Users", "Researcher" }
                });
        }
    }
}
