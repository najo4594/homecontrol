using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeControl.DataAccess.Migrations
{
    public partial class Fix_device_type_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceType_DeviceType_Id",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceType",
                table: "DeviceType");

            migrationBuilder.RenameTable(
                name: "DeviceType",
                newName: "DeviceTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceTypes",
                table: "DeviceTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceTypes_DeviceType_Id",
                table: "Devices",
                column: "DeviceType_Id",
                principalTable: "DeviceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql("DELETE FROM dbo.DeviceTypes");
            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.DeviceTypes ON;");
            migrationBuilder.Sql("INSERT INTO dbo.DeviceTypes (Id, Name) VALUES (1, 'Lampe')");
            migrationBuilder.Sql("INSERT INTO dbo.DeviceTypes (Id, Name) VALUES (2, 'Steckdose')");
            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.DeviceTypes OFF;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceTypes_DeviceType_Id",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceTypes",
                table: "DeviceTypes");

            migrationBuilder.RenameTable(
                name: "DeviceTypes",
                newName: "DeviceType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceType",
                table: "DeviceType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceType_DeviceType_Id",
                table: "Devices",
                column: "DeviceType_Id",
                principalTable: "DeviceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
