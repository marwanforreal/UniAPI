using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAPI.Migrations
{
    public partial class AddedM2M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CourseStudent",
                columns: new[] { "EnrolledCoursesId", "StudentsId" },
                values: new object[] { 4, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseStudent",
                keyColumns: new[] { "EnrolledCoursesId", "StudentsId" },
                keyValues: new object[] { 4, 1 });
        }
    }
}
