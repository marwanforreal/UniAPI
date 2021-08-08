using Microsoft.EntityFrameworkCore.Migrations;

namespace UniAPI.Migrations
{
    public partial class nullableClassRoomId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_ClassRooms_ClassRoomId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "ClassRoomId",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_ClassRooms_ClassRoomId",
                table: "Courses",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_ClassRooms_ClassRoomId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "ClassRoomId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_ClassRooms_ClassRoomId",
                table: "Courses",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
