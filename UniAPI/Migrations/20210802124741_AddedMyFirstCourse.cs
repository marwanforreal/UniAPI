using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAPI.Migrations
{
    public partial class AddedMyFirstCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "ClassRoomId", "DateTime", "LecturerId", "Name" },
                values: new object[] { 4, 3, new DateTime(2021, 10, 15, 15, 15, 15, 0, DateTimeKind.Unspecified), 2, "Introduction To Computer Science" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
