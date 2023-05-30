using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConferencePlanning.Data.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionnaires_AspNetUsers_ApplicationUserId",
                table: "Questionnaires");

            migrationBuilder.DropIndex(
                name: "IX_Questionnaires_ApplicationUserId",
                table: "Questionnaires");

            migrationBuilder.DeleteData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: new Guid("0926b409-6be4-48d5-ab21-3441e2f1337f"));

            migrationBuilder.DeleteData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: new Guid("1a0d8ae2-e1e7-4ef2-bb6e-74071de978d1"));

            migrationBuilder.DeleteData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: new Guid("833ee8bf-31dd-49fc-a254-2e3c3bbb2927"));

            migrationBuilder.DeleteData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: new Guid("a90cf8a0-758e-46e2-9be2-b559c4d5dcfb"));

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Questionnaires");

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "Id", "Addres", "Categories", "City", "Date", "EndTime", "FullTopic", "ModeratorId", "Name", "Organizer", "PhotoId", "ShortTopic", "StartTime", "Type" },
                values: new object[,]
                {
                    { new Guid("114468bd-3394-4b66-ac89-ca0ca043e9a1"), "Obrazova 9", new List<string> { "Math", "Chemistry", "IT" }, "Moscow", new DateOnly(2023, 5, 28), new TimeOnly(13, 28, 21, 467).Add(TimeSpan.FromTicks(736)), "Conference2", null, "Conference2", "Rut miit", new Guid("00000000-0000-0000-0000-000000000000"), "Conference2", new TimeOnly(13, 28, 21, 467).Add(TimeSpan.FromTicks(735)), "offline" },
                    { new Guid("2876a3b7-1afb-4c4c-81e5-a9a8049c2ff8"), "Obrazova 9", new List<string> { "Math", "Chemistry", "IT" }, "Moscow", new DateOnly(2023, 5, 28), new TimeOnly(13, 28, 21, 467).Add(TimeSpan.FromTicks(745)), "Conference4", null, "Conference4", "Rut miit", new Guid("00000000-0000-0000-0000-000000000000"), "Conference4", new TimeOnly(13, 28, 21, 467).Add(TimeSpan.FromTicks(744)), "offline" },
                    { new Guid("9024c52a-92fc-4ee8-b844-35a4d34d01e2"), "Obrazova 9", new List<string> { "Math", "Chemistry", "IT" }, "Moscow", new DateOnly(2023, 5, 28), new TimeOnly(13, 28, 21, 467).Add(TimeSpan.FromTicks(727)), "Conference1", null, "Conference1", "Rut miit", new Guid("00000000-0000-0000-0000-000000000000"), "Conference1", new TimeOnly(13, 28, 21, 467).Add(TimeSpan.FromTicks(722)), "offline" },
                    { new Guid("fbcca709-39e0-48d4-8ef5-1237a2d98519"), "Obrazova 9", new List<string> { "Math", "Chemistry", "IT" }, "Moscow", new DateOnly(2023, 5, 28), new TimeOnly(13, 28, 21, 467).Add(TimeSpan.FromTicks(741)), "Conference3", null, "Conference3", "Rut miit", new Guid("00000000-0000-0000-0000-000000000000"), "Conference3", new TimeOnly(13, 28, 21, 467).Add(TimeSpan.FromTicks(740)), "offline" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_UserId",
                table: "Questionnaires",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionnaires_AspNetUsers_UserId",
                table: "Questionnaires",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionnaires_AspNetUsers_UserId",
                table: "Questionnaires");

            migrationBuilder.DropIndex(
                name: "IX_Questionnaires_UserId",
                table: "Questionnaires");

            migrationBuilder.DeleteData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: new Guid("114468bd-3394-4b66-ac89-ca0ca043e9a1"));

            migrationBuilder.DeleteData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: new Guid("2876a3b7-1afb-4c4c-81e5-a9a8049c2ff8"));

            migrationBuilder.DeleteData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: new Guid("9024c52a-92fc-4ee8-b844-35a4d34d01e2"));

            migrationBuilder.DeleteData(
                table: "Conferences",
                keyColumn: "Id",
                keyValue: new Guid("fbcca709-39e0-48d4-8ef5-1237a2d98519"));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Questionnaires",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "Id", "Addres", "Categories", "City", "Date", "EndTime", "FullTopic", "ModeratorId", "Name", "Organizer", "PhotoId", "ShortTopic", "StartTime", "Type" },
                values: new object[,]
                {
                    { new Guid("0926b409-6be4-48d5-ab21-3441e2f1337f"), "Obrazova 9", new List<string> { "Math", "Chemistry", "IT" }, "Moscow", new DateOnly(2023, 5, 28), new TimeOnly(13, 23, 31, 174).Add(TimeSpan.FromTicks(1832)), "Conference4", null, "Conference4", "Rut miit", new Guid("00000000-0000-0000-0000-000000000000"), "Conference4", new TimeOnly(13, 23, 31, 174).Add(TimeSpan.FromTicks(1831)), "offline" },
                    { new Guid("1a0d8ae2-e1e7-4ef2-bb6e-74071de978d1"), "Obrazova 9", new List<string> { "Math", "Chemistry", "IT" }, "Moscow", new DateOnly(2023, 5, 28), new TimeOnly(13, 23, 31, 174).Add(TimeSpan.FromTicks(1823)), "Conference2", null, "Conference2", "Rut miit", new Guid("00000000-0000-0000-0000-000000000000"), "Conference2", new TimeOnly(13, 23, 31, 174).Add(TimeSpan.FromTicks(1822)), "offline" },
                    { new Guid("833ee8bf-31dd-49fc-a254-2e3c3bbb2927"), "Obrazova 9", new List<string> { "Math", "Chemistry", "IT" }, "Moscow", new DateOnly(2023, 5, 28), new TimeOnly(13, 23, 31, 174).Add(TimeSpan.FromTicks(1813)), "Conference1", null, "Conference1", "Rut miit", new Guid("00000000-0000-0000-0000-000000000000"), "Conference1", new TimeOnly(13, 23, 31, 174).Add(TimeSpan.FromTicks(1807)), "offline" },
                    { new Guid("a90cf8a0-758e-46e2-9be2-b559c4d5dcfb"), "Obrazova 9", new List<string> { "Math", "Chemistry", "IT" }, "Moscow", new DateOnly(2023, 5, 28), new TimeOnly(13, 23, 31, 174).Add(TimeSpan.FromTicks(1828)), "Conference3", null, "Conference3", "Rut miit", new Guid("00000000-0000-0000-0000-000000000000"), "Conference3", new TimeOnly(13, 23, 31, 174).Add(TimeSpan.FromTicks(1827)), "offline" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_ApplicationUserId",
                table: "Questionnaires",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionnaires_AspNetUsers_ApplicationUserId",
                table: "Questionnaires",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
