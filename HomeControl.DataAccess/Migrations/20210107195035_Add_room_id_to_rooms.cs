using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeControl.DataAccess.Migrations
{
    public partial class Add_room_id_to_rooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomId",
                table: "Rooms",
                column: "RoomId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Rooms");
        }
    }
}
