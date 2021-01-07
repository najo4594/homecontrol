using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeControl.DataAccess.Migrations
{
    public partial class Rename_rooms_roomId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Rooms_RoomId",
                table: "Devices");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Devices",
                newName: "Room_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Devices_RoomId",
                table: "Devices",
                newName: "IX_Devices_Room_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Rooms_Room_Id",
                table: "Devices",
                column: "Room_Id",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Rooms_Room_Id",
                table: "Devices");

            migrationBuilder.RenameColumn(
                name: "Room_Id",
                table: "Devices",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Devices_Room_Id",
                table: "Devices",
                newName: "IX_Devices_RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Rooms_RoomId",
                table: "Devices",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
