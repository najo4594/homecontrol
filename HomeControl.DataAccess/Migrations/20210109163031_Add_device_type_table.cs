using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeControl.DataAccess.Migrations
{
    public partial class Add_device_type_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeviceType_Id",
                table: "Devices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DeviceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceType_Id",
                table: "Devices",
                column: "DeviceType_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceType_DeviceType_Id",
                table: "Devices",
                column: "DeviceType_Id",
                principalTable: "DeviceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql("INSERT INTO dbo.DeviceType (Name) VALUES ('Lampe')");
            migrationBuilder.Sql("INSERT INTO dbo.DeviceType (Name) VALUES ('Steckdose')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceType_DeviceType_Id",
                table: "Devices");

            migrationBuilder.DropTable(
                name: "DeviceType");

            migrationBuilder.DropIndex(
                name: "IX_Devices_DeviceType_Id",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "DeviceType_Id",
                table: "Devices");
        }
    }
}
